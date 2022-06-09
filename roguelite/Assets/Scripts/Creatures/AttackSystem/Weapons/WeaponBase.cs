using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlobalCooldown))]
public abstract class WeaponBase : MonoBehaviour
{
    public float MinimalAttackDistance { get; private set; }
    public GlobalCooldown GlobalCooldown { get; private set; }
    public List<Type> AttackTypes { get; private set; }
    public UnityEvent<AttackData> OnAttackEvent { get; private set; }
    public UnityEvent OnAttackEndedEvent { get; private set; }

    protected Dictionary<Type, AttackBase> _attacks;

    private EffectList _effects;

    public virtual void InitializeWeapon(WeaponDataInfo dataInfo)
    {
        GlobalCooldown = GetComponent<GlobalCooldown>();
        GlobalCooldown.ResetCooldownTime(dataInfo.GlobalCooldownTime);
        _effects = GetComponentInChildren<EffectList>();
        OnAttackEvent = new UnityEvent<AttackData>();
        OnAttackEndedEvent = new UnityEvent();

        CreateAttacks(dataInfo.WeaponAttacks);
    }

    public virtual void UseAttack(Type attackType)
    {
        if (!CanAttack(attackType))
            return;

        var currentAttack = _attacks[attackType];
        OnAttackEvent.Invoke(currentAttack.AttackData);
        currentAttack.Attack();
        GlobalCooldown.TryRestartCooldown();
    }

    public bool CanAttack(Type attackType)
    {
        return GlobalCooldown.IsReady && _attacks[attackType].IsReady();
    }

    public AttackData GetAttackData(Type attackType)
    {
        return _attacks[attackType].AttackData;
    }

    protected void ActivateEffects(AttackEventArgs attackEventArgs)
    {
        OnAttackEndedEvent.Invoke();
        var effects = _effects.Effects.ToList();
        foreach (var effect in effects)
        {
            effect.ApplyEffect(attackEventArgs);
            Debug.Log($"{effect} worked on {attackEventArgs.DamagedTargets.Count} targets.");
        }
    }

    private void CreateAttacks(List<AttackType> attackTypes)    //  TODO: Говнокод, исправить
    {
        MinimalAttackDistance = float.MaxValue;
        AttackTypes = new List<Type>();
        _attacks = new Dictionary<Type, AttackBase>();
        var moveController = GetComponentInParent<MoveController>();

        foreach (var attackType in attackTypes)
        {
            var type = TypeConvertor.ConvertEnumToType(attackType);
            var attack = AttacksFactory.Instance.CreateObject(GetComponentInChildren<AttacksList>().gameObject, type);
            //attack.OnAttackStartedEvent.AddListener(_ => moveController.StopMoving());
            //attack.OnAttackPreparedEvent.AddListener(_ => moveController.ContinueMoving());
            attack.OnAttackCompletedEvent.AddListener(ActivateEffects);
            _attacks.Add(type, attack);
            AttackTypes.Add(type);

            SetMinimalDistance(attack.AttackData.AttackRadius);
        }

    }

    private void SetMinimalDistance(float radius)
    {
        if (radius < MinimalAttackDistance && radius != 0)
            MinimalAttackDistance = radius;
    }
}

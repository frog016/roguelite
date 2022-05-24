using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GlobalCooldown))]
public abstract class WeaponBase : MonoBehaviour
{
    public float MinimalAttackDistance { get; private set; }
    public GlobalCooldown GlobalCooldown { get; private set; }
    public List<Type> AttackTypes { get; private set; }

    protected Dictionary<Type, AttackBase> _attacks;

    private EffectsList _effects;

    public virtual void InitializeWeapon(WeaponDataInfo dataInfo)
    {
        GlobalCooldown = GetComponent<GlobalCooldown>();
        GlobalCooldown.ResetCooldownTime(dataInfo.GlobalCooldownTime);
        _effects = GetComponentInChildren<EffectsList>();

        CreateAttacks(dataInfo.WeaponAttacks);
    }

    public virtual void UseAttack(Type attackType)
    {
        var currentAttack = _attacks[attackType];
        if (!GlobalCooldown.IsReady || !currentAttack.IsReady())
            return;

        currentAttack.Attack();
        GlobalCooldown.TryRestartCooldown();
    }

    public AttackData GetAttackData(Type attackType)
    {
        return _attacks[attackType].AttackData;
    }

    protected void ActivateEffects(AttackEventArgs attackEventArgs)
    {
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
        var attackDrawer = GetComponent<GizmosAttackDrawer>();
        var moveController = GetComponentInParent<MoveController>();

        foreach (var attackType in attackTypes)
        {
            var type = TypeConvertor.ConvertEnumToType(attackType);
            var attack = AttacksFactory.Instance.CreateObject(GetComponentInChildren<AttacksList>().gameObject, type);
            attack.OnAttackStartedEvent.AddListener(attackDrawer.DrawAttack);
            attack.OnAttackStartedEvent.AddListener(_ => moveController.StopMoving());
            attack.OnAttackPreparedEvent.AddListener(_ => moveController.ContinueMoving());
            attack.OnAttackCompletedEvent.AddListener(ActivateEffects);
            _attacks.Add(type, attack);
            AttackTypes.Add(type);

            SetMinimalDistance(attack.AttackData.AttackRadius);
        }

    }

    private void PrepareBeforeAttack()
    {
        GetComponent<MoveController>().StopMoving();
    }

    private void SetMinimalDistance(float radius)
    {
        if (radius < MinimalAttackDistance && radius != 0)
            MinimalAttackDistance = radius;
    }
}

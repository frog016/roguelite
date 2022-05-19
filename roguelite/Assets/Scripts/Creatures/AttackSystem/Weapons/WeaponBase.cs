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

    private List<EffectBase> _effects;

    public virtual void InitializeWeapon(WeaponDataInfo dataInfo)
    {
        GlobalCooldown = GetComponent<GlobalCooldown>();
        _effects = GetComponentInChildren<EffectsList>().Effects;

        CreateAttacks(dataInfo.WeaponAttacks);
    }

    public virtual void UseAttack(Type attackType)
    {
        var currentAttack = _attacks[attackType];
        if (!GlobalCooldown.IsReady || !currentAttack.IsReady())
            return;

        var targets = currentAttack.Attack();
        Debug.Log($"{gameObject.name} deal damage to {targets.Count} targets using {currentAttack}.");
        GlobalCooldown.TryRestartCooldown();
        ActivateEffects(new AttackEventArgs(currentAttack, targets));
    }

    public bool IsReady(Type attackType)
    {
        return _attacks[attackType].IsReady();
    }

    protected void ActivateEffects(AttackEventArgs attackEventArgs)
    {
        var effects = _effects.ToList();
        foreach (var effect in effects)
        {
            effect.ApplyEffect(attackEventArgs);
            Debug.Log($"{effect} worked on {attackEventArgs.DamagedTargets.Count} targets.");
        }
    }

    private void CreateAttacks(List<AttackType> attackTypes)
    {
        MinimalAttackDistance = float.MaxValue;
        AttackTypes = new List<Type>();
        _attacks = new Dictionary<Type, AttackBase>();

        foreach (var attackType in attackTypes)
        {
            var type = TypeConvertor.ConvertEnumToType(attackType);
            var attack = AttacksFactory.Instance.CreateObject(GetComponentInChildren<AttacksList>().gameObject, type);
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

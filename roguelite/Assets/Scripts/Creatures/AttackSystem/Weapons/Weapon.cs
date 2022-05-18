using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float MinimalAttackDistance { get; private set; }
    public List<Type> AttackTypes { get; private set; }

    protected Dictionary<Enum, IAttack> _attacks;

    private EffectsList _effects;

    public virtual void InitializeWeapon(WeaponData data)
    {
        _effects = GetComponentInChildren<EffectsList>();
        CreateAttacks(data.AttackTypes);
    }

    public bool IsReady(Enum attackType)
    {
        return _attacks[attackType].IsReady();
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

    private void CreateAttacks(List<AttackType> attackTypes)
    {
        MinimalAttackDistance = float.MaxValue;

        foreach (var attackType in attackTypes)
        {
            var type = TypeConvertor.ConvertEnumToType(attackType);
            var attack = AttacksFactory.Instance.CreateObject(gameObject, type);
            _attacks.Add(attackType, attack);
            AttackTypes.Add(type);

            SetMinimalDistance((attack as Attack).Data.AttackRadius);
        }
    }

    private void SetMinimalDistance(float radius)
    {
        if (radius < MinimalAttackDistance && radius != 0)
            MinimalAttackDistance = radius;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class DualKatanas : MonoBehaviour, IWeapon
{
    private List<IEffect> _weaponEffects;
    private AttackParameters _parameters;

    private void Awake()
    {
        _weaponEffects = new List<IEffect>();
    }

    public void Initialize(AttackParameters parameters)
    {
        _parameters = parameters;
    }

    public void Attack(DamageableObject target)
    {
        ActivateEffects(target);
        target.ApplyDamage(_parameters.Damage);
    }

    public void AlternateAttack(DamageableObject target)
    {
        ActivateEffects(target);
        target.ApplyDamage(_parameters.Damage);
    }

    private void ActivateEffects(DamageableObject target)
    {
        foreach (var effect in _weaponEffects)
            effect.ApplyEffect(target);
    }
}

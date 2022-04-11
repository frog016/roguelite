using System.Collections.Generic;
using UnityEngine;

public class DualKatanas : IWeapon
{
    private readonly WeaponData _parameters;
    private readonly List<IEffect> _weaponEffects;

    public DualKatanas(WeaponData data)
    {
        _weaponEffects = new List<IEffect>();
        _parameters = data;
    }

    public WeaponData GetWeaponData()
    {
        return _parameters;
    }

    public void Attack(DamageableObject target)
    {
        ActivateEffects(target);
        target.ApplyDamage(_parameters.AttackParameters.Damage);
        Debug.Log($"{target} apply common attack with {_parameters.AttackParameters.Damage}, current HP = {target.Health}");
    }

    public void AlternateAttack(DamageableObject target)
    {
        ActivateEffects(target);
        target.ApplyDamage(_parameters.AttackParameters.Damage);
        Debug.Log($"{target} apply alternate attack with {_parameters.AttackParameters.Damage}, current HP = {target.Health}");
    }

    private void ActivateEffects(DamageableObject target)
    {
        foreach (var effect in _weaponEffects)
            effect.ApplyEffect(target);
    }
}

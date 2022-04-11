using System.Collections.Generic;

public class DualKatanas : IWeapon
{
    private List<IEffect> _weaponEffects;
    private AttackParameters _parameters;

    public DualKatanas(WeaponData data)
    {
        _weaponEffects = new List<IEffect>();
        _parameters = data.AttackParameters;
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

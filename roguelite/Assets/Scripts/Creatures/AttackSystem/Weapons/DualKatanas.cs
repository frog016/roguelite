using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(IAttack), typeof(IAttack))]
public class DualKatanas : IWeapon
{
    private List<IEffect> _weaponEffects;

    private IAttack _firstAttack;
    private IAttack _secondAttack;

    public DualKatanas(WeaponData data, TargetsFinder targetsFinder)
    {
        _weaponEffects = new List<IEffect>();
        _firstAttack = new CommonAttack(data.FirstAttackData, targetsFinder);
        _secondAttack = new AlternateAttack(data.SecondAttackData, targetsFinder);
    }

    public void Attack()
    {
        if (!_firstAttack.IsReady())
            return;

        (_firstAttack as Attack)?.OnAttack.AddListener(ActivateEffects);
        _firstAttack.Attack();
    }

    public void AlternateAttack()
    {
        if (!_secondAttack.IsReady())
            return;

        (_secondAttack as Attack)?.OnAttack.AddListener(ActivateEffects);
        _secondAttack.Attack();
    }

    private void ActivateEffects(List<DamageableObject> targets)
    {
        var target = targets.FirstOrDefault();
        foreach (var effect in _weaponEffects)
            effect.ApplyEffect(target);
    }
}

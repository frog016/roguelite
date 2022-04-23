using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IAttack), typeof(IAttack))]
public class DualKatanas : IWeapon
{
    public UnityEvent<List<DamageableObject>> OnAttack { get; set; }

    private IAttack _firstAttack;
    private IAttack _secondAttack;

    public DualKatanas(WeaponData data, TargetsFinder targetsFinder)
    {
        _firstAttack = new CommonAttack(data.FirstAttackData, targetsFinder);
        _secondAttack = new AlternateAttack(data.SecondAttackData, targetsFinder);
        OnAttack = new UnityEvent<List<DamageableObject>>();
    }

    public void Attack()
    {
        if (!_firstAttack.IsReady())
            return;

        _firstAttack.Attack();
        OnAttack.Invoke((_firstAttack as Attack)?.LastTargets);
    }

    public void AlternateAttack()
    {
        if (!_secondAttack.IsReady())
            return;

        _secondAttack.Attack();
        OnAttack.Invoke((_firstAttack as Attack)?.LastTargets);
    }
}

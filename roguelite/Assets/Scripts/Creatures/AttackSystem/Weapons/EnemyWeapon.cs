using System.Collections.Generic;
using UnityEngine.Events;

public class EnemyWeapon : IWeapon
{
    public UnityEvent<List<DamageableObject>> OnAttack { get; set; }

    private IAttack _firstAttack;
    private IAttack _secondAttack;

    public EnemyWeapon(WeaponData data, TargetsFinder targetsFinder)
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
        return;
    }
}

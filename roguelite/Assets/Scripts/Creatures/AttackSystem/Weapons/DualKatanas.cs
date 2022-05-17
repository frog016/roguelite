using UnityEngine.Events;

public class DualKatanas : IWeapon
{
    public UnityEvent<AttackEventArgs> OnAttackEvent { get; set; }

    private IAttack _firstAttack;
    private IAttack _secondAttack;

    public DualKatanas(WeaponData data, TargetsFinder targetsFinder)
    {
        _firstAttack = new CommonAttack(data.FirstAttackData, targetsFinder);
        _secondAttack = new CircleAttack(data.SecondAttackData, targetsFinder);
        OnAttackEvent = new UnityEvent<AttackEventArgs>();
    }

    public void Attack()
    {
        if (!_firstAttack.IsReady())
            return;

        OnAttackEvent.Invoke(new AttackEventArgs(_firstAttack, _firstAttack.Attack()));
    }

    public void AlternateAttack()
    {
        if (!_secondAttack.IsReady())
            return;

        OnAttackEvent.Invoke(new AttackEventArgs(_secondAttack, _firstAttack.Attack()));
    }
}

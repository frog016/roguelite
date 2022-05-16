using UnityEngine.Events;

public class Attack
{
    public UnityEvent OnAttackReady { get; private set; }

    protected readonly AttackData _data;
    protected readonly Cooldown _cooldown;
    protected readonly TargetsFinder _targetsFinder;

    public Attack(AttackData attackData, TargetsFinder targetsFinder)
    {
        _data = attackData;
        _cooldown = attackData.Cooldown;
        _targetsFinder = targetsFinder;
        OnAttackReady = _cooldown.OnCooldownRestarted;
    }
}

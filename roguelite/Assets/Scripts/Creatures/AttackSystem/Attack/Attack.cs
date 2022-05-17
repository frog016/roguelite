using UnityEngine.Events;

public class Attack
{
    public UnityEvent OnAttackReady { get; private set; }
    public readonly AttackData Data;

    protected readonly Cooldown _cooldown;
    protected readonly TargetsFinder _targetsFinder;

    public Attack(AttackData attackData, TargetsFinder targetsFinder)
    {
        Data = attackData;
        _cooldown = attackData.Cooldown;
        _targetsFinder = targetsFinder;
        OnAttackReady = _cooldown.OnCooldownRestarted;
    }
}

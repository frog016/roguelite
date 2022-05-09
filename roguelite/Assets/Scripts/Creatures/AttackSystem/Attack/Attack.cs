using System.Collections.Generic;

public class Attack
{
    protected readonly AttackData _data;
    protected readonly Cooldown _cooldown;
    protected readonly TargetsFinder _targetsFinder;

    public Attack(AttackData attackData, TargetsFinder targetsFinder)
    {
        _data = attackData;
        _cooldown = attackData.Cooldown;
        _targetsFinder = targetsFinder;
    }
}

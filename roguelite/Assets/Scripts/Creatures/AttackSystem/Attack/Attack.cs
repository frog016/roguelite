using System.Collections.Generic;

public class Attack
{
    public List<DamageableObject> LastTargets { get; protected set; }

    protected readonly AttackData _data;
    protected readonly Cooldown _cooldown;
    protected readonly TargetsFinder _targetsFinder;

    public Attack(AttackData attackData, TargetsFinder targetsFinder)
    {
        _data = attackData;
        _cooldown = attackData.Cooldown;
        _targetsFinder = targetsFinder;
        LastTargets = new List<DamageableObject>();
    }
}

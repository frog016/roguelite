using System.Collections.Generic;

public class CommonAttack : Attack, IAttack
{
    public CommonAttack(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInSector(Data.AttackRadius, Data.AttackAngleDegrees);
        _cooldown.TryRestartCooldown();
        if (targets.Count == 0)
            return new List<DamageableObject>();

        foreach (var target in targets)
        {
            target.ApplyDamage(Data.Damage);
        }

        return targets;
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

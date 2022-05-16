using System.Collections.Generic;

public class CleaveKick : Attack, IAttack
{
    public CleaveKick(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInSector(_data.AttackRadius, _data.AttackAngleDegrees);
        _cooldown.TryRestartCooldown();
        if (targets.Count == 0)
            return new List<DamageableObject>();

        foreach (var target in targets)
        {
            target.ApplyDamage(_data.Damage);
        }

        return targets;
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

using System.Collections.Generic;

public class CircleAttack : Attack, IAttack
{
    public CircleAttack(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(_data.AttackRadius);
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

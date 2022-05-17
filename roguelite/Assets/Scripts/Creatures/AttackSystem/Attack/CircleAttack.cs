using System.Collections.Generic;

public class CircleAttack : Attack, IAttack
{
    public CircleAttack(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(Data.AttackRadius);
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

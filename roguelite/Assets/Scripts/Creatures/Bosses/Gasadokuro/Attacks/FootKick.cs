using System.Collections.Generic;

public class FootKick : AttackBase
{
    public override List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(AttackData.AttackRadius, false);
        _cooldown.TryRestartCooldown();
        if (targets.Count == 0)
            return new List<DamageableObject>();

        foreach (var target in targets)
        {
            target.ApplyDamage(AttackData.Damage);
        }

        return targets;
    }
}

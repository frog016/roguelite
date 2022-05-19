using System.Collections.Generic;
using UnityEngine;

public class CommonAttack : AttackBase
{
    [SerializeField][Range(0, 360)] private float _attackAngleDegrees;

    public override List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInSector(AttackData.AttackRadius, _attackAngleDegrees);
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

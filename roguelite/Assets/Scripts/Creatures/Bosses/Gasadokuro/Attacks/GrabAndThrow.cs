using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class GrabAndThrow : AttackBase
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
            ThrowTarget(target, target.transform.position - _targetsFinder.transform.position);
        }

        return targets;
    }

    private void ThrowTarget(DamageableObject target, Vector2 direction)
    {
        target.GetComponent<MoveController>().Dash(direction);
    }
}

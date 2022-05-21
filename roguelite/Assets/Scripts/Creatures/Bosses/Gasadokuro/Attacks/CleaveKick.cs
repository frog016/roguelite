using System.Collections;
using UnityEngine;

public class CleaveKick : AttackBase
{
    [SerializeField][Range(0, 360)] private float _attackAngleDegrees;

    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        var targets = _targetsFinder.FindTargetsInSector(AttackData.AttackRadius, _attackAngleDegrees);
        _cooldown.TryRestartCooldown();

        foreach (var target in targets)
        {
            target.ApplyDamage(AttackData.Damage);
        }

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));
    }
}

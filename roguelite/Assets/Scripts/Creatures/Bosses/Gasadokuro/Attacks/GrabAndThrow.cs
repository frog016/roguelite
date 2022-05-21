using System.Collections;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class GrabAndThrow : AttackBase
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
            ThrowTarget(target, target.transform.position - _targetsFinder.transform.position);
        }

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));
    }

    private void ThrowTarget(DamageableObject target, Vector2 direction)
    {
        target.GetComponent<MoveController>().Dash(direction);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrushingLeap : AttackBase
{
    private MoveController _moveController;
    private Rigidbody2D _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _moveController = GetComponentInParent<MoveController>();
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        var targets = _targetsFinder.FindTargetsInCircle(2 * AttackData.AttackRadius);
        var target = targets.FirstOrDefault();

        var direction = _moveController.Direction;
        if (target != null)
            direction = (target.transform.position - transform.position).normalized;

        StartCoroutine(LeapAndStomp(direction));
    }

    private IEnumerator LeapAndStomp(Vector2 direction)
    {
        _moveController.Dash(direction);
        yield return new WaitUntil(() => _rigidbody.velocity.magnitude < 1e-12);

        var targets = _targetsFinder.FindTargetsInCircle(AttackData.AttackRadius);
        _cooldown.TryRestartCooldown();

        foreach (var damageableObject in targets)
        {
            damageableObject.ApplyDamage(AttackData.Damage);
        }

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));
    }
}

using System.Collections;
using System.Linq;
using UnityEngine;

public class ThrowStone : AttackBase
{
    [SerializeField] private GameObject _projectilePrefab;

    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        var targets = _targetsFinder.FindTargetsInCircle(AttackData.AttackRadius);
        var target = targets.FirstOrDefault();

        if (target != null)
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity)
                .GetComponent<Projectile>();
            _cooldown.TryRestartCooldown();
            projectile.Shoot(target, AttackData.Damage);
        }

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));  //  TODO: Переделать тут
    }
}
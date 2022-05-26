using System.Collections;
using System.Linq;
using UnityEngine;

public class BowShoot : AttackBase
{
    [SerializeField] private GameObject _projectile;

    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        var targets = _targetsFinder.FindTargetsInCircle(AttackData.AttackRadius);
        var target = targets.FirstOrDefault();

        if (target == null)
            yield break;

        var projectile = Instantiate(_projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        _cooldown.TryRestartCooldown();
        projectile.Shoot(target, AttackData.Damage);

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));  //  TODO: Переделать тут
    }
}

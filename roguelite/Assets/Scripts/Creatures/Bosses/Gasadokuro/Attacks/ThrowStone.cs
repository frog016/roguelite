using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowStone : AttackBase
{
    [SerializeField] private GameObject _projectilePrefab;

    public override List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(2 * AttackData.AttackRadius, false);
        var player = targets.FirstOrDefault(target => target.GetComponent<HeroSamurai>() != null);

        if (player is null)
            return new List<DamageableObject>();

        var projectile = Object.Instantiate(_projectilePrefab, _targetsFinder.transform.position, Quaternion.identity).GetComponent<Projectile>();
        _cooldown.TryRestartCooldown();
        projectile.Shoot(player, AttackData.Damage);
        
        return targets;
    }
}
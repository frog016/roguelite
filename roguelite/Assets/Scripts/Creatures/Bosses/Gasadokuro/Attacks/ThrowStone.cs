using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowStone : Attack, IAttack
{
    private readonly GameObject _projectilePrefab;

    public ThrowStone(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
        _projectilePrefab = PrefabsFinder.FindObjectOfType<Projectile>();
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(2 * Data.AttackRadius, false);
        var player = targets.FirstOrDefault(target => target.GetComponent<HeroSamurai>() != null);

        if (player is null)
            return new List<DamageableObject>();

        var projectile = Object.Instantiate(_projectilePrefab, _targetsFinder.transform.position, Quaternion.identity).GetComponent<Projectile>();
        _cooldown.TryRestartCooldown();
        projectile.Shoot(player, Data.Damage);
        
        return targets;
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}
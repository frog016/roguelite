using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrushingLeap : Attack, IAttack
{
    public CrushingLeap(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInCircle(2 * _data.AttackRadius, false);
        var player = targets.FirstOrDefault(target => target.GetComponent<HeroSamurai>() != null);

        if (player is null)
            return new List<DamageableObject>();

        _targetsFinder.GetComponentInParent<Creature>().StartCoroutine(LeapAndStomp(player.transform.position - _targetsFinder.transform.position));

        return targets;
    }

    private IEnumerator LeapAndStomp(Vector2 direction)
    {
        _targetsFinder.GetComponentInParent<MoveController>().Dash(direction);
        var rigidbody = _targetsFinder.GetComponentInParent<Rigidbody>();
        yield return new WaitUntil(() => rigidbody.velocity.magnitude < 1e-12);

        var targets = _targetsFinder.FindTargetsInCircle(_data.AttackRadius);
        _cooldown.TryRestartCooldown();

        foreach (var damageableObject in targets)
        {
            damageableObject.ApplyDamage(_data.Damage);
        }
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

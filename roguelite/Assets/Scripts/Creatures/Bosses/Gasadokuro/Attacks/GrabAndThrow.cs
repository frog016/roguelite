using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;

public class GrabAndThrow : Attack, IAttack
{
    public GrabAndThrow(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        var targets = _targetsFinder.FindTargetsInSector(Data.AttackRadius, Data.AttackAngleDegrees);
        _cooldown.TryRestartCooldown();
        if (targets.Count == 0)
            return new List<DamageableObject>();

        foreach (var target in targets)
        {
            target.ApplyDamage(Data.Damage);
            ThrowTarget(target, target.transform.position - _targetsFinder.transform.position);
        }

        return targets;
    }

    private void ThrowTarget(DamageableObject target, Vector2 direction)
    {
        target.GetComponent<MoveController>().Dash(direction);
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

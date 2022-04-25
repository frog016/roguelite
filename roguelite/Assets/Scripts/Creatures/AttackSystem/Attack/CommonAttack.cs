public class CommonAttack : Attack, IAttack
{
    public CommonAttack(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public void Attack()
    {
        var targets = _targetsFinder.FindTargetsInSector(_data.AttackRadius, _data.AttackAngleDegrees);
        if (targets.Count == 0)
            return;

        LastTargets = targets;
        _cooldown.TryRestartCooldown();
        foreach (var target in targets)
        {
            target.ApplyDamage(_data.Damage);
        }
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

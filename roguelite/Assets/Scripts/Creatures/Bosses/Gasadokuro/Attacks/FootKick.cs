using System.Collections;

public class FootKick : AttackBase
{
    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        var targets = _targetsFinder.FindTargetsInCircle(AttackData.AttackRadius);
        _cooldown.TryRestartCooldown();

        foreach (var target in targets)
        {
            target.ApplyDamage(AttackData.Damage);
        }

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, targets));
    }
}

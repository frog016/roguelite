public class DoubleStrikeEffect : EffectBase
{
    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        attackEventArgs.UsedAttack.Attack();
    }
}

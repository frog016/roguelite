public class DoubleStrikeEffect : NegativeEffect
{
    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        attackEventArgs.UsedAttack.Attack();
    }
}

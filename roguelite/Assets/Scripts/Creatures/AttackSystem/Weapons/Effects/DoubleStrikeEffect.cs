public class DoubleStrikeEffect : Effect, IEffect
{
    public void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        attackEventArgs.UsedAttack.Attack();
    }
}

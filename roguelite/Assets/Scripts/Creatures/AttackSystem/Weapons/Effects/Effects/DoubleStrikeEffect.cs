public class DoubleStrikeEffect : EffectBase
{
    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability) || attackEventArgs.DamagedTargets.Count <= 0)
            return;

        var data = EffectData as DoubleStrikeEffectData;
        var damage = attackEventArgs.UsedAttack.AttackData.Damage;

        attackEventArgs.UsedAttack.AttackData.Damage *= data.SecondStrikeDamageCoefficient;
        attackEventArgs.UsedAttack.Attack();
        attackEventArgs.UsedAttack.AttackData.Damage = damage;
    }
}

public class CriticalStrikeEffect : EffectBase
{
    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability))
            return;

        var data = EffectData as CriticalStrikeEffectData;
        var damage = attackEventArgs.UsedAttack.AttackData.Damage * data.CriticalHitCoefficient;

        foreach (var target in attackEventArgs.DamagedTargets)
        {
            target.ApplyDamage(damage);
            PlayVisualEffect(target.transform);
        }
    }
}

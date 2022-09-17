public class LifeStealEffect : EffectBase
{
    private DamageableObject _myHealth;

    public override void Initialize(EffectData data)
    {
        base.Initialize(data);
        _myHealth = GetComponentInParent<DamageableObject>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability) || attackEventArgs.DamagedTargets.Count <= 0)
            return;

        PlayVisualEffect();
        foreach (var target in attackEventArgs.DamagedTargets)
            StealHealth(target);
    }

    private void StealHealth(DamageableObject target)
    {
        var data = EffectData as LifeStealEffectData;
        _myHealth.ApplyHealth(data.LifeStealAmount);
        target.ApplyDamage(data.LifeStealAmount);
    }
}

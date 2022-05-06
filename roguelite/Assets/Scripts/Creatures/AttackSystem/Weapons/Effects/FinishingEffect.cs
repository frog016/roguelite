using UnityEngine;

public class FinishingEffect : Effect, IEffect
{
    private float _procProbability;
    private float _finishingThreshold;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _procProbability = data.ProcProbability;
        _finishingThreshold = data.FinishingThreshold;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability) || target.Health > _finishingThreshold)
            return;

        target.ApplyDamage(_finishingThreshold);
    }
}

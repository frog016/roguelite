using System.Collections.Generic;
using System.Linq;

public class FinishingEffect : Effect, IEffect
{
    private float _finishingThreshold;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _finishingThreshold = data.FinishingThreshold;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in targets.Where(t => t.Health <= _finishingThreshold))
            target.ApplyDamage(_finishingThreshold);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalStrikeEffect : Effect, IEffect
{
    private float _criticalHitCoeff;
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _criticalHitCoeff = data.CriticalHitCoeff;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        //var damage = GetComponentInParent
        foreach (var target in targets)
        {
          //  target.ApplyDamage();
        }
    }
}

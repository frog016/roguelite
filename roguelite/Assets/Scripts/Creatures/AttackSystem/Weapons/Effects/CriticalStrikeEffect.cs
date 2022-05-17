using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalStrikeEffect : Effect, IEffect
{
    private float _criticalHitCoeff;
<<<<<<< HEAD

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _criticalHitCoeff = data.CriticalHitCoefficient;
=======
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _criticalHitCoeff = data.CriticalHitCoeff;
>>>>>>> weapon-effects
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        //var damage = GetComponentInParent
        foreach (var target in targets)
        {
<<<<<<< HEAD
            //  target.ApplyDamage();
=======
          //  target.ApplyDamage();
>>>>>>> weapon-effects
        }
    }
}

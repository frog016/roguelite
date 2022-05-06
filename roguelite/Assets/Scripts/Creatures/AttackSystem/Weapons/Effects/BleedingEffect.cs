using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingEffect : Effect, IEffect
{
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        StartCoroutine(ApplyDamageOverTime(targets));
    }

    private IEnumerator ApplyDamageOverTime(List<DamageableObject> targets)
    {
        var counter = 0;
        while (counter < _duration)
        {
            foreach (var target in targets)
                target.ApplyDamage(_parameters.Damage);
            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }
    }
}

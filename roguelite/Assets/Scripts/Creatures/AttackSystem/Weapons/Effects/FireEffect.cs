using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : Effect, IEffect
{
    private List<DamageableObject> TargetsUnderEffect;
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        TargetsUnderEffect = new List<DamageableObject>();
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in targets)
        {
            if(!TargetsUnderEffect.Contains(target))
                StartCoroutine(ApplyDamageOverTime(target));
        }
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        TargetsUnderEffect.Add(target);
        var counter = 0;
        while (counter < _duration)
        {
            target.ApplyDamage(_parameters.Damage);

            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }

        TargetsUnderEffect.Remove(target);
    }
}

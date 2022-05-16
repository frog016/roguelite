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
        StartCoroutine(ApplyDamageOverTime(targets));
    }

    private IEnumerator ApplyDamageOverTime(List<DamageableObject> targets)
    {
        var counter = 0;
        while (counter < _duration)
        {
            foreach (var target in targets)
            {
                if (!TargetsUnderEffect.Contains(target))
                {
                    target.ApplyDamage(_parameters.Damage);
                    TargetsUnderEffect.Add(target);
                }
            }
            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }

        targets.ForEach(x => TargetsUnderEffect.Remove(x));
    }
}

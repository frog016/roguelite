using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireEffect : EffectBase
{
    private HashSet<DamageableObject> _targetsUnderEffect;

    public override void Initialize(EffectData data)
    {
        base.Initialize(data);
        _targetsUnderEffect = new HashSet<DamageableObject>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability))
            return;

        foreach (var target in attackEventArgs.DamagedTargets
                     .Where(target => !_targetsUnderEffect.Contains(target)))
        {
            PlayVisualEffect(target.transform);
            target.OnObjectDeath.AddListener(() => StopCoroutine(ApplyDamageOverTime(target)));
            StartCoroutine(ApplyDamageOverTime(target));
        }
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        _targetsUnderEffect.Add(target);
        var counter = 0;
        while (counter < EffectData.Duration)
        {
            target.ApplyDamage(EffectData.Damage);
            yield return new WaitForSeconds(1f);
            counter++;
        }

        _targetsUnderEffect.Remove(target);
    }
}

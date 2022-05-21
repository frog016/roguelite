using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireEffect : EffectBase
{
    private HashSet<DamageableObject> _targetsUnderEffect;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _targetsUnderEffect = new HashSet<DamageableObject>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in attackEventArgs.DamagedTargets.Where(target => !_targetsUnderEffect.Contains(target)))
            StartCoroutine(ApplyDamageOverTime(target));
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        _targetsUnderEffect.Add(target);
        var counter = 0;
        while (counter < _duration)
        {
            target.ApplyDamage(_parameters.Damage);

            yield return new WaitForSeconds(_parameters.CooldownTime);
            counter++;
        }

        _targetsUnderEffect.Remove(target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : Effect, IEffect
{
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in targets)
            target.ApplyDamage(_parameters.Damage);

        StartCoroutine(Stun(targets));
    }

    public IEnumerator Stun(List<DamageableObject> targets)
    {
        yield return new WaitForSeconds(_duration);
    }
}

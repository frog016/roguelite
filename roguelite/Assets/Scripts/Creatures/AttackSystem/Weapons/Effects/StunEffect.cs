using System.Collections;
using UnityEngine;

public class StunEffect : Effect, IEffect
{
    private AttackData _parameters;
    private float _procProbability;
    private float _duration;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        target.ApplyDamage(_parameters.Damage);
        StartCoroutine(Stun(target));
    }

    public IEnumerator Stun(DamageableObject target)
    {
        yield return new WaitForSeconds(_duration);
    }
}

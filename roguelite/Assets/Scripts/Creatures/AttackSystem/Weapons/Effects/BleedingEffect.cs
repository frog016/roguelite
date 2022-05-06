using System.Collections;
using UnityEngine;

public class BleedingEffect : Effect, IEffect
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

        StartCoroutine(ApplyDamageOverTime(target));
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        var counter = 0;
        while (counter < _duration)
        {
            target.ApplyDamage(_parameters.Damage);
            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }
    }
}

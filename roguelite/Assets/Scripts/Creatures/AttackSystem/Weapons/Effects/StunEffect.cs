using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : MonoBehaviour, IEffect
{
    private AttackParameters _parameters;
    private float _procProbability;
    private float _duration;

    public StunEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        target.ApplyDamage(_parameters.Damage);
        Stun(target);

    }

    public IEnumerator Stun(DamageableObject target)
    {
        // отклюение управления
        yield return new WaitForSeconds(_duration);
        // включение управления
    }
}

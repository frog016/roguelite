using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : MonoBehaviour, IEffect
{
    private AttackParameters _parameters;
    private float _procProbability;
    private float _duration;
    private float _additionalDamage;

    public StunEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
        _additionalDamage = data.AdditionalDamage;
    }

    public void ApplyEffect(DamageableObject target)
    {



    }
}

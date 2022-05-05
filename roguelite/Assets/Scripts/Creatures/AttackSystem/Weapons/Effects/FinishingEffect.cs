using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingEffect : MonoBehaviour, IEffect
{
    private float _procProbability;
    private float _finishingThreshold;
    private bool _isEvolved;

    public FinishingEffect(EffectData data)
    {
        _procProbability = data.ProcProbability;
        _finishingThreshold = data.FinishingThreshold;
        _isEvolved = data.IsEvolved;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        if (target.Health < _finishingThreshold) // доделать проверку на босса и эволв версию(нет макс хп)
            target.ApplyDamage(_finishingThreshold);
    }
}

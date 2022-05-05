using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedEffect : MonoBehaviour, IEffect
{
    private bool _isEvolved;
    private float _duration;
    private int _maxStacks;
    private int Stacks;

    public AttackSpeedEffect(EffectData data)
    {
        _isEvolved = data.IsEvolved;
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (Stacks < _maxStacks)
            Stacks++;
    }
}

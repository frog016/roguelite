using UnityEngine;

public class AttackSpeedEffect : Effect, IEffect
{
    private float _duration;
    private int _maxStacks;
    private int Stacks;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (Stacks < _maxStacks)
            Stacks++;
    }
}

using System.Collections.Generic;

public class AttackSpeedEffect : Effect, IEffect
{
    private int _maxStacks;
    private int _stacksCount;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (_stacksCount < _maxStacks)
            _stacksCount++;
    }
}

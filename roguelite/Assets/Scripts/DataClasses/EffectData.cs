using System;
using UnityEngine;

[Serializable]
public class EffectData : Data
{
    [SerializeField] private EffectType _effectType;
    [SerializeField] private AttackParameters _attackParameters;
    [SerializeField] private float _procProbability;
    [SerializeField] private float _duration;

    public AttackParameters AttackParameters => _attackParameters;
    public float ProcProbability => _procProbability;
    public float Duration => _duration;

    public override Enum GetDataType()
    {
        return _effectType;
    }
}

public enum EffectType
{
    FireEffect,
    AirEffect,
    LifeStealEffect,
    StunEffect,
    BleedingEffect,
    FinishingEffect,
    AttackSpeedEffect,
    ChainLightningEffect,
    DoubleStrikeEffect,
    DashIncreasedDamageEffect,
    WalkSpeedEffect,
    EvasionEffect,
    BerserkEffect,
    HealingEffect,
    CriticalStrikeEffect
}

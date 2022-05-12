using System;
using UnityEngine;

[Serializable]
public class EffectData : Data
{
    [SerializeField] private EffectType _effectType;
    [SerializeField] private AttackData _attackParameters;
    [SerializeField] private float _procProbability;
    [SerializeField] private float _duration;
    [SerializeField] private float _knockBackForce;
    [SerializeField] private float _lifeStealAmount;
    [SerializeField] private float _finishingThreshold;
    [SerializeField] private int _maxStacks;
    [SerializeField] private float _increasedAttackSpeedCoeff;
    [SerializeField] private int _maxChainLinks;
    [SerializeField] private float _chainLinksDamage;
    [SerializeField] private float _areaRadius;
    [SerializeField] private float _criticalHitCoeff;


    public AttackData AttackParameters => _attackParameters;
    public float ProcProbability => _procProbability;
    public float Duration => _duration;
    public float KnockBackForce => _knockBackForce;
    public float LifeStealAmount => _lifeStealAmount;
    public float FinishingThreshold => _finishingThreshold;
    public int MaxStacks => _maxStacks;
    public float IncreasedAttackSpeedÑoeff => _increasedAttackSpeedCoeff;
    public int MaxChainLinks => _maxChainLinks;
    public float ChainLinksDamage => _chainLinksDamage;
    public float AreaRadius => _areaRadius;
    public float CriticalHitCoeff => _criticalHitCoeff;

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

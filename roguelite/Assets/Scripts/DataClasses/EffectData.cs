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
<<<<<<< HEAD
    [SerializeField] private float _increasedAttackSpeedCoefficient;
    [SerializeField] private int _maxChainLinks;
    [SerializeField] private float _chainLinksDamage;
    [SerializeField] private float _areaRadius;
    [SerializeField] private float _criticalHitCoefficient;
=======
    [SerializeField] private float _increasedAttackSpeedCoeff;
    [SerializeField] private int _maxChainLinks;
    [SerializeField] private float _chainLinksDamage;
    [SerializeField] private float _areaRadius;
    [SerializeField] private float _criticalHitCoeff;

>>>>>>> weapon-effects

    public AttackData AttackParameters => _attackParameters;
    public float ProcProbability => _procProbability;
    public float Duration => _duration;
    public float KnockBackForce => _knockBackForce;
    public float LifeStealAmount => _lifeStealAmount;
    public float FinishingThreshold => _finishingThreshold;
    public int MaxStacks => _maxStacks;
<<<<<<< HEAD
    public float IncreasedAttackSpeedCoefficient => _increasedAttackSpeedCoefficient;
    public int MaxChainLinks => _maxChainLinks;
    public float ChainLinksDamage => _chainLinksDamage;
    public float AreaRadius => _areaRadius;
    public float CriticalHitCoefficient => _criticalHitCoefficient;
=======
    public float IncreasedAttackSpeedÑoeff => _increasedAttackSpeedCoeff;
    public int MaxChainLinks => _maxChainLinks;
    public float ChainLinksDamage => _chainLinksDamage;
    public float AreaRadius => _areaRadius;
    public float CriticalHitCoeff => _criticalHitCoeff;
>>>>>>> weapon-effects

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
    AttackSpeedEffect,
    ChainLightningEffect,
    DoubleStrikeEffect,
    CriticalStrikeEffect
}

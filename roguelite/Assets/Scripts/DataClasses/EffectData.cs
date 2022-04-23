using System;
using UnityEngine;

[Serializable]
public class EffectData : Data
{
    [SerializeField] private EffectType _effectType;
    [SerializeField] private AttackParameters _attackParameters;
    [SerializeField] private float _procProbability;
    [SerializeField] private float _duration;
    [SerializeField] private float _knockBackForce;
    //[SerializeField] private PolygonCollider2D _area;
    [SerializeField] private float _lifestealAmount;
    [SerializeField] private float _additionalDamage;


    public AttackParameters AttackParameters => _attackParameters;
    public float ProcProbability => _procProbability;
    public float Duration => _duration;
    public float KnockBackForce => _knockBackForce;
    //public PolygonCollider2D Area => _area;
    public float LifestealAmount => _lifestealAmount;
    public float AdditionalDamage => _additionalDamage;
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

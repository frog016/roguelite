using System;
using UnityEngine;

[Serializable]
public class EffectData : Data
{
    [SerializeField] private bool _isEvolved;
    [SerializeField] private EffectType _effectType;
    [SerializeField] private AttackData _attackParameters;
    [SerializeField] private float _procProbability;
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _knockBackForce;
    //[SerializeField] private PolygonCollider2D _area;
    [SerializeField] private float _lifestealAmount;
    [SerializeField] private float _finishingThreshold;
    [SerializeField] private int _maxStacks;
    [SerializeField] private int _maxChainLinks;

    public bool IsEvolved => _isEvolved;
    public AttackData AttackParameters => _attackParameters;
    public float ProcProbability => _procProbability;
    public float Duration => _duration;
    public GameObject Player => _player;
    public float KnockBackForce => _knockBackForce;
    //public PolygonCollider2D Area => _area;
    public float LifestealAmount => _lifestealAmount;
    public float FinishingThreshold => _finishingThreshold;
    public int MaxStacks => _maxStacks;
    public int MaxChainLinks => _maxChainLinks;
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

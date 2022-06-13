using UnityEngine;

public abstract class EffectData : ScriptableData
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _duration;
    [SerializeField] protected float _procProbability;
    [SerializeField] protected EffectInfo _info;

    public float Damage => _damage;
    public float Duration => _duration;
    public float ProcProbability => _procProbability;
    public EffectInfo Info => _info;
}

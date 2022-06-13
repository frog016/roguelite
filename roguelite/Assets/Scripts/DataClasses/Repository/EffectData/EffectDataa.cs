using UnityEngine;

public abstract class EffectDataa : ScriptableData
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _procProbability;

    public float Damage => _damage;
    public float Duration => _duration;
    public float ProcProbability => _procProbability;
}

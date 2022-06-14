using UnityEngine;

public abstract class AttackData : ScriptableData
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackRadius;
    [SerializeField] protected float _angleDegrees;
    [SerializeField] protected float _cooldownTime;
    [SerializeField] protected float _delayBeforeAttack;

    public float Damage { get => _damage; set => _damage = value; }
    public float AttackRadius => _attackRadius;
    public float AngleDegrees => _angleDegrees;
    public float CooldownTime => _cooldownTime;
    public float DelayBeforeAttack => _delayBeforeAttack;

    protected virtual void Initialize(float damage, float radius, float angleDegrees, float cooldown,
        float delay)
    {
        _damage = damage;
        _attackRadius = radius;
        _angleDegrees = angleDegrees;
        _cooldownTime = cooldown;
        _delayBeforeAttack = delay;
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance(GetType()) as AttackData;
        copy.Initialize(_damage, _attackRadius, _angleDegrees, _cooldownTime, _delayBeforeAttack);
        return copy;
    }
}

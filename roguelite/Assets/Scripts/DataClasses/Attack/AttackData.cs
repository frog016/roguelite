using System;
using UnityEngine;

[Serializable]
public class AttackData : Data
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _delayBeforeAttack;

    public float Damage => _damage;
    public float AttackRadius => _attackRadius;
    public float CooldownTime => _cooldownTime;
    public float DelayBeforeAttack => _delayBeforeAttack;

    public override Enum GetDataType() => default;
}

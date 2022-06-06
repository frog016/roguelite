using System;
using UnityEngine;

[Serializable]
public class AttackData : Data
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _angleDegrees;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _delayBeforeAttack;

    public float Damage { get => _damage; set => _damage = value; }
    public float AttackRadius => _attackRadius;
    public float AngleDegrees => _angleDegrees;
    public float CooldownTime => _cooldownTime;
    public float DelayBeforeAttack => _delayBeforeAttack;

    public override Enum GetDataType() => default;
}

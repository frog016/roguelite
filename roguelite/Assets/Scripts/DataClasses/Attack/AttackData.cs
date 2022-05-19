using System;
using UnityEngine;

[Serializable]
public class AttackData : Data
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackSpeed;

    public float Damage => _damage;
    public float AttackRadius => _attackRadius;
    public float AttackSpeed => _attackSpeed;

    public override Enum GetDataType() => default;
}

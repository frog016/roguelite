using System;
using UnityEngine;

[Serializable]
public class AttackParameters
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;

    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
}

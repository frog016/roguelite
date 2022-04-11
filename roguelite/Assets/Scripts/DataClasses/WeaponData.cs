using System;
using UnityEngine;

[Serializable]
public class WeaponData : Data
{
    [SerializeField] private AttackParameters _attackParameters;

    public AttackParameters AttackParameters => _attackParameters;
}

public enum WeaponType
{
    DualKatanas,
    TwoHandedTati
}

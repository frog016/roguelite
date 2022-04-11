using System;
using UnityEngine;

[Serializable]
public class WeaponData : Data
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private AttackParameters _attackParameters;

    public AttackParameters AttackParameters => _attackParameters;

    public override Enum GetDataType()
    {
        return _weaponType;
    }
}

public enum WeaponType
{
    DualKatanas,
    TwoHandedTati
}

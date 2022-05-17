using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData : Data
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private List<AttackType> _attackTypes;

    public List<AttackType> AttackTypes => _attackTypes;

    public override Enum GetDataType()
    {
        return _weaponType;
    }
}

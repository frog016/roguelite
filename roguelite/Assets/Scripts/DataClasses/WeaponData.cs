using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData : Data
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private float _globalCooldownTime;
    [SerializeField] private List<AttackType> _attackTypes;

    public float GlobalCooldownTime => _globalCooldownTime;
    public List<AttackType> AttackTypes => _attackTypes;

    public override Enum GetDataType()
    {
        return _weaponType;
    }
}

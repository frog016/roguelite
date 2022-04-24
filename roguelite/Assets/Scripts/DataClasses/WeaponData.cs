using System;
using UnityEngine;

[Serializable]
public class WeaponData : Data
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private AttackData _firstAttackData;
    [SerializeField] private AttackData _secondAttackData;

    public AttackData FirstAttackData => _firstAttackData;
    public AttackData SecondAttackData => _secondAttackData;

    public override Enum GetDataType()
    {
        return _weaponType;
    }
}

public enum WeaponType
{
    DualKatanas,
    TwoHandedTati,
    EnemyWeapon
}

using UnityEngine;

public class Creature : DamageableObject
{
    [SerializeField] private WeaponType _weaponType;

    protected override void Awake()
    {
        base.Awake();
        WeaponFactory.Instance.CreateObject(gameObject, TypeConvertor.ConvertEnumToType(_weaponType));
    }
}

using UnityEngine;

public class Creature : DamageableObject
{
    [SerializeField] private WeaponType _weaponType;

    private void Start()
    {
        WeaponFactory.Instance.CreateObject(gameObject, TypeConvertor.ConvertEnumToType(_weaponType));
    }
}

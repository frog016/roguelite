using UnityEngine;

public class Creature : DamageableObject
{
    public void InitializeCreature(WeaponType weaponType)
    {
        WeaponFactory.Instance.CreateObject(gameObject, TypeConvertor.ConvertEnumToType(weaponType));
    }
}

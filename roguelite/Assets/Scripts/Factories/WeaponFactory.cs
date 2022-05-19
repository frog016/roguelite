using System;
using Database.MutableDatabases;
using UnityEngine;

public class WeaponFactory : SingletonObject<WeaponFactory>, IFactory<IWeapon>
{
    public IWeapon CreateObject(GameObject parent, Type weaponType)
    {
        var data = WeaponDatabase.Instance.GetDataByType(weaponType);
        var weaponObject = new GameObject(weaponType.Name);

        var effects = new GameObject("Effects");
        effects.AddComponent<EffectsList>();
        effects.transform.SetParent(weaponObject.transform);

        var weapon = weaponObject.gameObject.AddComponent(weaponType) as Weapon;
        weaponObject.AddComponent<TargetsFinder>();
        weapon.InitializeWeapon(data);
        weaponObject.transform.SetParent(parent.transform);

        return (IWeapon)weapon;
    }
}
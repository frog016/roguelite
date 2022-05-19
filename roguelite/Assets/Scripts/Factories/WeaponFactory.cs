using System;
using Database.MutableDatabases;
using UnityEngine;

public class WeaponFactory : SingletonObject<WeaponFactory>, IFactory<WeaponBase>
{
    public WeaponBase CreateObject(GameObject parent, Type weaponType)
    {
        var data = WeaponDatabase.Instance.GetDataByType(weaponType);

        var weaponObject = Instantiate(data.Prefab, parent.transform);
        var weapon = weaponObject.GetComponent<WeaponBase>();
        weapon.InitializeWeapon(data);

        return weapon;
    }
}
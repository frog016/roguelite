using System;
using System.Reflection;
using Database.MutableDatabases;
using UnityEngine;

public class WeaponFactory : SingletonObject<WeaponFactory>, IFactory<IWeapon>
{
    public void CreateObject(GameObject parent, Type weaponType)
    {
        var data = WeaponDatabase.Instance.GetDataByType(weaponType);
        var weaponObject = new GameObject(weaponType.Name);
        data.FirstAttackData.AddCooldown(weaponObject.AddComponent<Cooldown>());
        data.SecondAttackData.AddCooldown(weaponObject.AddComponent<Cooldown>());

        var weapon = weaponObject.gameObject.AddComponent<Weapon>();
        weapon.SetWeapon((IWeapon)Activator.CreateInstance(weaponType, data, weaponObject.gameObject.AddComponent<TargetsFinder>()), data);

        weaponObject.transform.SetParent(parent.transform);
    }
}
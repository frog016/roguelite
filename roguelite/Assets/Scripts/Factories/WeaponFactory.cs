using System;
using Database.MutableDatabases;
using UnityEngine;

public class WeaponFactory : SingletonObject<WeaponFactory>, IFactory<IWeapon>
{
    public IWeapon CreateObject(GameObject parent, Type weaponType)
    {
        var data = WeaponDatabase.Instance.GetDataByType(weaponType);
        var weaponObject = new GameObject(weaponType.Name);
        data.FirstAttackData.AddCooldown(weaponObject.AddComponent<Cooldown>());
        data.SecondAttackData.AddCooldown(weaponObject.AddComponent<Cooldown>());

        var effects = new GameObject("Effects");
        effects.AddComponent<EffectsList>();
        var weapon = weaponObject.gameObject.AddComponent<Weapon>();

        var weaponInterface =
            (IWeapon)Activator.CreateInstance(weaponType, data, weaponObject.gameObject.AddComponent<TargetsFinder>());
        weapon.SetWeapon(weaponInterface, data);

        weaponObject.transform.SetParent(parent.transform);
        effects.transform.SetParent(weaponObject.transform);

        return weaponInterface;
    }
}
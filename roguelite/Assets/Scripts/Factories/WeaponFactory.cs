using System;
using Database.MutableDatabases;

public class WeaponFactory : SingletonObject<WeaponFactory>, IFactory<IWeapon>
{
    public IWeapon CreateObject(Type weaponType)
    {
        var data = WeaponDatabase.Instance.GetDataByType(weaponType);
        var effect = (IWeapon)Activator.CreateInstance(weaponType, data);
        return effect;
    }
}
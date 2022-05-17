using System;
using Database.MutableDatabases;
using UnityEngine;

public class AttacksFactory : SingletonObject<AttacksFactory>, IFactory<IAttack>
{
    public IAttack CreateObject(GameObject parent, Type objectType)
    {
        var data = AttacksDatabase.Instance.GetDataByType(objectType);
        data.AddCooldown(parent.AddComponent<Cooldown>());
        var attack = (IAttack)Activator.CreateInstance(objectType, data, parent.GetComponent<TargetsFinder>());
        return attack;
    }
}

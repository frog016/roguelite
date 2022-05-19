using System;
using Database.MutableDatabases;
using UnityEngine;

public class AttacksFactory : SingletonObject<AttacksFactory>, IFactory<AttackBase>
{
    public AttackBase CreateObject(GameObject parent, Type objectType)
    {
        var data = AttacksDatabase.Instance.GetDataByType(objectType);
        var attacksObject = Instantiate(data.Prefab, parent.transform);
        var attack = attacksObject.GetComponent<AttackBase>();
        attack.Initialize(data);

        return attack;
    }
}

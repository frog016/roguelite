using System;
using Database.MutableDatabases;
using UnityEngine;

public class CreatureFactory : SingletonObject<CreatureFactory>, IFactory<Creature>
{
    public Creature CreateObject(GameObject parent, Type objectType)
    {
        var data = CreatureDatabase.Instance.GetDataByType(objectType);
        var creature = Instantiate(data.Prefab, parent.transform.position, Quaternion.identity);

        var damageableObject = creature.GetComponent<Creature>();
        damageableObject.Health = data.MaxHealth;
        damageableObject.MaxHealth = data.MaxHealth;

        damageableObject.InitializeCreature(data.Weapon);

        return damageableObject;
    }
}

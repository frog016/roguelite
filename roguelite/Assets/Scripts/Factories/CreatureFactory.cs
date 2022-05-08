using System;
using Database.MutableDatabases;
using UnityEngine;

public class CreatureFactory : SingletonObject<CreatureFactory>, IFactory<Creature>
{
    public void CreateObject(GameObject parent, Type objectType)
    {
        var data = CreatureDatabase.Instance.GetDataByType(objectType);
        var creature = Instantiate(data.Prefab, parent.transform.position, parent.transform.rotation);

        var damageableObject = creature.GetComponent<DamageableObject>();
        damageableObject.Health = data.MaxHealth;
        damageableObject.MaxHealth = data.MaxHealth;
    }
}

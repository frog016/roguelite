using System;
using UnityEngine;

public class CreatureFactory : SingletonObject<CreatureFactory>, IFactory<Creature>
{
    public Creature CreateObject(GameObject parent, Type objectType)
    {
        var data = CreatureDataRepository.Instance.FindDataByAssociatedType(objectType);
        var creature = Instantiate(data.CreaturePrefab, parent.transform.position, Quaternion.identity);

        var damageableObject = creature.GetComponent<Creature>();
        damageableObject.Health = data.MaxHealth;
        damageableObject.MaxHealth = data.MaxHealth;

        creature.GetComponent<MoveController>().Speed = data.MoveSpeed;

        damageableObject.InitializeCreature(data.WeaponType);

        return damageableObject;
    }
}

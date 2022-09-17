using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/CreatureData/CreatureData", fileName = "CreatureData")]
public class CreatureData : ScriptableData
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _creaturePrefab;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private MovementData _movementData;

    public float MaxHealth => _maxHealth;
    public GameObject CreaturePrefab => _creaturePrefab;
    public Type WeaponType => _weaponPrefab.GetComponent<WeaponBase>().GetType();
    public MovementData MovementData => _movementData;

    public override Type GetAssociatedObjectType()
    {
        return _creaturePrefab.GetComponent<Creature>().GetType();
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}

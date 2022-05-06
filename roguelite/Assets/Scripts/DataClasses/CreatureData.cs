using System;
using UnityEngine;

[Serializable]
public class CreatureData : Data
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _prefab;

    public float MaxHealth => _maxHealth;
    public GameObject Prefab => _prefab;

    public override Enum GetDataType()
    {
        throw new NotImplementedException();
    }
}

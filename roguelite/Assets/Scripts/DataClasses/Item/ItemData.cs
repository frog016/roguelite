using System;
using UnityEngine;

[Serializable]
public class ItemData : Data
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private float _restoredHealth;
    [SerializeField] private int _usesCount;
    [SerializeField] private float _increaseDamage;

    public float RestoredHealth => _restoredHealth;
    public int UsesCount => _usesCount;
    public float IncreaseDamage => _increaseDamage;

    public override Enum GetDataType()
    {
        return _itemType;
    }
}

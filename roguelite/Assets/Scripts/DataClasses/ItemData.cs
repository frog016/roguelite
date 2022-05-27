using System;
using UnityEngine;

[Serializable]
public class ItemData : Data
{
    [SerializeField] private float _restoredHealth;

    public float RestoredHealth => _restoredHealth;

    public override Enum GetDataType()
    {
        throw new NotImplementedException();
    }
}

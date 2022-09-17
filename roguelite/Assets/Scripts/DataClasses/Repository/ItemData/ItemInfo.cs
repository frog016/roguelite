using System;
using UnityEngine;

[Serializable]
public class ItemInfo : Info
{
    [SerializeField] private float _cost;

    public float Cost => _cost;
}

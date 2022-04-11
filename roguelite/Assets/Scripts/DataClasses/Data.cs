using System;
using UnityEngine;

[Serializable]
public abstract class Data
{
    [SerializeField] private string _name;

    public string Name => _name;

    public abstract Enum GetDataType();
}
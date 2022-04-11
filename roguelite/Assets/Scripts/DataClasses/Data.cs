using System;
using UnityEngine;

[Serializable]
public class Data
{
    [SerializeField] private string _name;
    [SerializeField] private Enum _dataType;

    public string Name => _name;
    public Enum DataType => _dataType;
}

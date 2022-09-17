using System;
using UnityEngine;

[Serializable]
public class Range
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;

    public int Min => _min;
    public int Max => _max;
}

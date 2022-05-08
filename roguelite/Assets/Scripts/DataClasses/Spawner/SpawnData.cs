using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnData
{
    public readonly List<SpawnUnitsData> _units;

    public SpawnData()
    {
        _units = new List<SpawnUnitsData>();
    }
}

using System;
using System.Collections.Generic;

[Serializable]
public class SpawnData
{
    public readonly List<SpawnUnitsData> Units;

    public SpawnData(List<SpawnUnitsData> units = null)
    {
        Units = units ?? new List<SpawnUnitsData>();
    }

    public void AddUnitsData(SpawnUnitsData data) => Units.Add(data);
}

using System;

[Serializable]
public class SpawnUnitsData
{
    public readonly CreatureType CreatureType;
    public readonly int Count;

    public SpawnUnitsData(CreatureType creatureType, int count)
    {
        CreatureType = creatureType;
        Count = count;
    }
}

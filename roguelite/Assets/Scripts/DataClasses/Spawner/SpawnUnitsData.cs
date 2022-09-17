using System;

[Serializable]
public class SpawnUnitsData
{
    public readonly Type CreatureType;
    public readonly int Count;

    public SpawnUnitsData(Type creatureType, int count)
    {
        CreatureType = creatureType;
        Count = count;
    }
}

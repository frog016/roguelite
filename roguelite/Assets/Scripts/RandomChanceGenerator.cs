using UnityEngine;

public static class RandomChanceGenerator
{
    public static bool IsEventHappen(float chance)
    {
        return GetChance() <= chance;
    }

    public static float GetChance()
    {
        return Random.value;
    }
}

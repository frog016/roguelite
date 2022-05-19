using UnityEngine;

public static class RandomChanceGenerator
{
    public static bool IsEventHappened(float chance)
    {
        return GetChance() <= chance;
    }

    public static float GetChance()
    {
        return Random.value;
    }
}

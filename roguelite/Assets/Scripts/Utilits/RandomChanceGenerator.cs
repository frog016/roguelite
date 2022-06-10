using System.Collections.Generic;
using System.Linq;
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

    public static List<T> GetRandomItems<T>(this IEnumerable<T> collection, int count)
    {
        var listCollection = collection.ToList();

        var chances = new List<float>();
        for (var i = 0; i < listCollection.Count; i++)
            chances.Add(1f / listCollection.Count);

        return GetRandomItemsWithChances(listCollection, chances, count);
    }

    public static List<T> GetRandomItemsWithChances<T>(this IEnumerable<T> collection, List<float> chances, int count)
    {
        var listCollection = collection.ToList();
        var chanceList = CreateChanceList(chances);
        var used = new HashSet<T>();

        var maxCount = Mathf.Min(count, listCollection.Count);
        var items = new List<T>();
        while (items.Count < maxCount)
        {
            var probability = Random.value;
            var index = chanceList.FindLastIndex(element => probability <= element);
            var randomValue = listCollection[index];
            if (used.Contains(randomValue))
                continue;

            items.Add(randomValue);
            used.Add(randomValue);
        }

        return items;
    }

    private static List<float> CreateChanceList(List<float> chances)
    {
        var result = new List<float>();
        var probability = 0f;
        foreach (var chance in chances)
        {
            probability += chance;
            result.Add(probability);
        }
        
        if (probability == 0)
            result.Add(1f);

        return result;
    }
}

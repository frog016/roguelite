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

    public static List<T> GetRandomItemsOfCollection<T>(this IEnumerable<T> collection, int count)
    {
        var listCollection = collection.ToList();
        var used = new HashSet<T>();

        var maxCount = Mathf.Min(count, listCollection.Count);
        var items = new List<T>();
        while (items.Count < maxCount)
        {
            var randomValue = listCollection[Random.Range(0, listCollection.Count)];
            if (used.Contains(randomValue))
                randomValue = listCollection[Random.Range(0, listCollection.Count)];

            items.Add(randomValue);
            used.Add(randomValue);
        }

        return items;
    }
}

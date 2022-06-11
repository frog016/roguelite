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

    public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> collection, int count)
    {
        var listCollection = collection.ToList();
        var dictionaryCollection = listCollection.ToIndexedDictionary();

        var maxCount = Mathf.Min(count, dictionaryCollection.Count);
        for (var i = 0; i < maxCount; i++)
        {
            var key = Random.Range(0, dictionaryCollection.Count);
            var randomValue = dictionaryCollection[key];
            yield return randomValue;
            dictionaryCollection.Remove(key);

            if (key < dictionaryCollection.Count - 1)
                dictionaryCollection.RenameKey(key + 1, key);
        }
    }

    //public static List<T> GetRandomItemsWithChances<T>(this IEnumerable<T> collection, List<float> chances, int count)
    //{
    //    var listCollection = collection.ToList();
    //    var chanceList = CreateChanceList(chances);
    //    var used = new HashSet<T>();

    //    var maxCount = Mathf.Min(count, listCollection.Count);
    //    var items = new List<T>();
    //    while (items.Count < maxCount)
    //    {
    //        var probability = Random.value;
    //        var index = chanceList.FindLastIndex(element => probability <= element);
    //        var randomValue = listCollection[index];
    //        if (used.Contains(randomValue))
    //            continue;

    //        items.Add(randomValue);
    //        used.Add(randomValue);
    //    }

    //    return items;
    //}

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

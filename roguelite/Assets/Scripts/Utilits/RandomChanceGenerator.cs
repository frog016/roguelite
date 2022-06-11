using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public static IEnumerable<T> GetRandomItemsWithChances<T>(this IEnumerable<T> collection, List<float> chances, int count)
    {
        var listCollection = collection.ToList();
        var dictionaryCollection = listCollection.ToIndexedDictionary();
        var chanceList = CreateChanceList(chances);

        var maxCount = Mathf.Min(count, dictionaryCollection.Count);
        for (var i = 0; i < maxCount; i++)
        {
            var probability = Random.value;
            if (probability > 0.99)
                probability = 0.99f;

            var key = chanceList.First(pair => probability >= pair.Value.Item1 && probability < pair.Value.Item2).Key;
            yield return dictionaryCollection[key];
            dictionaryCollection.Remove(key);
            chanceList.Remove(key);

            if (key < dictionaryCollection.Count - 1)
            {
                dictionaryCollection.RenameKey(key + 1, key);
                chanceList.RenameKey(key + 1, key);
            }
        }
    }

    private static Dictionary<int, Tuple<float, float>> CreateChanceList(List<float> chances)
    {
        var result = new List<Tuple<float, float>>();
        var probability = 0f;
        for (var i = 0; i < chances.Count; i++)
        {
            result.Add(Tuple.Create(probability, probability + chances[i]));
            probability += chances[i];
        }

        return result.ToIndexedDictionary(); 
    }
}

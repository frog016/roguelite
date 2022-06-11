using System;
using System.Collections.Generic;
using System.Linq;

public static class DictionaryExtension
{
    public static Dictionary<int, T> ToIndexedDictionary<T>(this List<T> list)
    {
        var result = Enumerable
            .Range(0, list.Count)
            .Zip(list, (index, value) => (index, value))
            .ToDictionary(tuple => tuple.index, tuple => tuple.value);

        return result;
    }

    public static void RenameKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey oldKey, TKey newKey)
    {
        var value = dictionary[oldKey];
        dictionary.Remove(oldKey);
        dictionary.Add(newKey, value);
    }

    public static void RenameAllKeysFrom<TValue>(this Dictionary<int, TValue> dictionary, int from)
    {
        var last = dictionary.Last().Key;
        for (var i = from; i <= last; i++)
        {
            RenameKey(dictionary, i, i - 1);
        }
    }
}

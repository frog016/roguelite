using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PrefabsFinder
{
    public static GameObject FindObjectOfType<T>(string path = "")
    {
        return FindObjectsOfType<T>().FirstOrDefault();
    }

    public static List<GameObject> FindObjectsOfType<T>(string path = "")
    {
        var prefabs = Resources.LoadAll("Prefabs" + path, typeof(GameObject));
        return prefabs.Cast<GameObject>().Where(gameObject => gameObject.GetComponent<T>() != null).ToList();
    }
}

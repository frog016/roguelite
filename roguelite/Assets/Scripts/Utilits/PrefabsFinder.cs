using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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

    private static GameObject GetNonSceneObject<T>(IEnumerable<T> prefabs)
    {
        return (prefabs as List<GameObject>)?
            .FirstOrDefault(prefab => 
                EditorUtility.IsPersistent(prefab.transform.root.gameObject) &&
                !(prefab.hideFlags == HideFlags.NotEditable || 
                  prefab.hideFlags == HideFlags.HideAndDontSave));
    }
}

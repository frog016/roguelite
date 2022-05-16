using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class PrefabsFinder
{
    public static GameObject FindObjectOfType<T>()
    {
        var prefabs = Resources.FindObjectsOfTypeAll(typeof(T)) as IEnumerable<T>;
        return GetNonSceneObject(prefabs);
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

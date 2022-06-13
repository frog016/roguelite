using System;
using UnityEngine;

[Serializable]
public abstract class ScriptableData : ScriptableObject
{
    public virtual Type GetAssociatedObjectType()
    {
        return GetType();
    }

    public abstract ScriptableData Copy();
}

using System;
using UnityEngine;

public abstract class ScriptableData : ScriptableObject
{
    public virtual Type GetDataType()
    {
        return GetType();
    }
}

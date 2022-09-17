using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/Items/DoubleCoinsKeyData", fileName = "DoubleCoinsKeyData")]
public class DoubleCoinsKeyData : ItemData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(DoubleCoinsKey);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<DoubleCoinsKeyData>();
        copy.Initialize(_usesCount, _info);
        return copy;
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/Items/RandomReplacementBagData", fileName = "RandomReplacementBagData")]
public class RandomReplacementBagData : ItemData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(RandomReplacementBag);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<RandomReplacementBagData>();
        copy.Initialize(_usesCount, _info);
        return copy;
    }
}
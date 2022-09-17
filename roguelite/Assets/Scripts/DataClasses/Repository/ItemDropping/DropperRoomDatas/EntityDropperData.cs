using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/ItemDroppers/EntityDropperData", fileName = "EntityDropperData")]
public class EntityDropperData : MoneyDropperData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(EntityMoneyDropperRoom);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<EntityDropperData>();
        copy.Initialize(_droppingChance, _resultDescription, _range);
        return copy;
    }
}
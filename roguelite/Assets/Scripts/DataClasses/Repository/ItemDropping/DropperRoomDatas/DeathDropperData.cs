using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/ItemDroppers/DeathDropperData", fileName = "DeathDropperData")]
public class DeathDropperData : MoneyDropperData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(DeathMoneyDropperRoom);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<DeathDropperData>();
        copy.Initialize(_droppingChance, _resultDescription, _range);
        return copy;
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/ItemDroppers/GoldenDropperData", fileName = "GoldenDropperData")]
public class GoldenDropperData : MoneyDropperData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(GoldenMoneyDropperRoom);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<GoldenDropperData>();
        copy.Initialize(_droppingChance, _resultDescription, _range);
        return copy;
    }
}
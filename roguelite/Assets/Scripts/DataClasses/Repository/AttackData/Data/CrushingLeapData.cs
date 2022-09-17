using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/CrushingLeapData", fileName = "CrushingLeapData")]
public class CrushingLeapData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(CrushingLeap);
    }
}
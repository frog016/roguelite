using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/ThrowStoneData", fileName = "ThrowStoneData")]
public class ThrowStoneData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(ThrowStone);
    }
}
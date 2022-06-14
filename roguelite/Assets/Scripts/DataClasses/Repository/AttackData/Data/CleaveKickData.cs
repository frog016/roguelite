using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/CleaveKickData", fileName = "CleaveKickData")]
public class CleaveKickData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(CleaveKick);
    }
}
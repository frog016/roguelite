using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/FootKickData", fileName = "FootKickData")]
public class FootKickData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(FootKick);
    }
}
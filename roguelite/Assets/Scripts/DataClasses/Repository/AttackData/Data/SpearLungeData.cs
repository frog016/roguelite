using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/SpearLungeData", fileName = "SpearLungeData")]
public class SpearLungeData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(SpearLunge);
    }
}
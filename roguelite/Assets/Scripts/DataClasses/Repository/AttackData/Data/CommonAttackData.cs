using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/CommonAttackData", fileName = "CommonAttackData")]
public class CommonAttackData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(CommonAttack);
    }
}
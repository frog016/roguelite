using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/CircleAttackData", fileName = "CircleAttackData")]
public class CircleAttackData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(CircleAttack);
    }
}
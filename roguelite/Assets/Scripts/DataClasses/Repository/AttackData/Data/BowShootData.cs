using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/BowShootData", fileName = "BowShootData")]
public class BowShootData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(BowShoot);
    }
}

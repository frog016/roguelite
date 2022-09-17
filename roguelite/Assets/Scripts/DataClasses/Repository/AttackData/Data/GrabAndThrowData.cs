using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/AttackData/GrabAndThrowData", fileName = "GrabAndThrowData")]
public class GrabAndThrowData : AttackData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(GrabAndThrow);
    }
}
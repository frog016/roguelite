using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/StunEffectData", fileName = "StunEffectData")]
public class StunEffectData : EffectData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(StunEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
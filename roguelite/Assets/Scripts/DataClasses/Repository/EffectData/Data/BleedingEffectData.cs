using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/BleedingEffectData", fileName = "BleedingEffectData")]
public class BleedingEffectData : EffectData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(BleedingEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/FireEffectData", fileName = "FireEffectData")]
public class FireEffectData : EffectData
{
    public override Type GetAssociatedObjectType()
    {
        return typeof(FireEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}

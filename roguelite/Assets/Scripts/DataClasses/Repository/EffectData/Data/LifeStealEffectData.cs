using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/LifeStealEffectData", fileName = "LifeStealEffectData")]
public class LifeStealEffectData : EffectData
{
    [SerializeField] private float _lifeStealAmount;

    public float LifeStealAmount => _lifeStealAmount;

    public override Type GetAssociatedObjectType()
    {
        return typeof(LifeStealEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
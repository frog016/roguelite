using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/AirEffectData", fileName = "AirEffectData")]
public class AirEffectData : EffectData
{
    [SerializeField] private float _knockBackForce;

    public float KnockBackForce => _knockBackForce;

    public override Type GetAssociatedObjectType()
    {
        return typeof(AirEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
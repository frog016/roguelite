using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/DoubleStrikeEffectData", fileName = "DoubleStrikeEffectData")]
public class DoubleStrikeEffectData : EffectData
{
    [SerializeField] private float _secondStrikeDamageCoefficient;

    public float SecondStrikeDamageCoefficient => _secondStrikeDamageCoefficient;

    public override Type GetAssociatedObjectType()
    {
        return typeof(DoubleStrikeEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
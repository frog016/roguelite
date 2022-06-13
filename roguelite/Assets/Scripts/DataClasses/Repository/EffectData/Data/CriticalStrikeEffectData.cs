using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/CriticalStrikeEffectData", fileName = "CriticalStrikeEffectData")]
public class CriticalStrikeEffectData : EffectData
{
    [SerializeField] private float _criticalHitCoefficient;

    public float CriticalHitCoefficient => _criticalHitCoefficient;

    public override Type GetAssociatedObjectType()
    {
        return typeof(CriticalStrikeEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
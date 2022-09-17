using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/AttackSpeedEffectData", fileName = "AttackSpeedEffectData")]
public class AttackSpeedEffectData : EffectData
{
    [SerializeField] private int _maxStackNumber;
    [SerializeField] private float _increasedAttackSpeedCoefficient;

    public int MaxStackNumber => _maxStackNumber;
    public float IncreasedAttackSpeedCoefficient => _increasedAttackSpeedCoefficient;

    public override Type GetAssociatedObjectType()
    {
        return typeof(AttackSpeedEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
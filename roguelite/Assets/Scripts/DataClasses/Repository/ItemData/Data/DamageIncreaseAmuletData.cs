using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/Items/DamageIncreaseAmuletData", fileName = "DamageIncreaseAmuletData")]
public class DamageIncreaseAmuletData : ItemData
{
    [SerializeField] private float _increaseDamage;

    public float IncreaseDamage => _increaseDamage;

    protected void Initialize(int usesCount, ItemInfo info, float increaseDamage)
    {
        base.Initialize(usesCount, info);
        _increaseDamage = increaseDamage;
    }

    public override Type GetAssociatedObjectType()
    {
        return typeof(DamageIncreaseAmulet);
    }
    
    public override ScriptableData Copy()
    {
        var copy = CreateInstance<DamageIncreaseAmuletData>();
        copy.Initialize(_usesCount, _info, _increaseDamage);
        return copy;
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/Items/HealPotionData", fileName = "HealPotionData")]
public class HealPotionData : ItemData
{
    [SerializeField] private float _restoredHealth;

    public float RestoredHealth => _restoredHealth;

    protected void Initialize(int usesCount, ItemInfo info, float restoredHealth)
    {
        base.Initialize(usesCount, info);
        _restoredHealth = restoredHealth;
    }

    public override Type GetAssociatedObjectType()
    {
        return typeof(HealPotion);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<HealPotionData>();
        copy.Initialize(_usesCount, _info, _restoredHealth);
        return copy;
    }
}

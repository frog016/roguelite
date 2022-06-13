public class HealPotion : Item
{
    protected override void UseItem()
    {
        var data = _itemData as HealPotionData;

        if (data.UsesCount <= 0)
            return;

        GetComponentInParent<DamageableObject>().ApplyHealth(data.RestoredHealth);
        data.UsesCount--;
        Destroy(this);
    }
}

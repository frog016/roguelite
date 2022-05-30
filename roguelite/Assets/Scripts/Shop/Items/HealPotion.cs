public class HealPotion : Item
{
    protected override void UseItem()
    {
        if (_usesCount <= 0)
            return;

        GetComponentInParent<DamageableObject>().ApplyHeath(_data.RestoredHealth);
        _usesCount--;
        Destroy(this);
    }
}

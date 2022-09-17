public class DamageIncreaseAmulet : Item
{
    private WeaponBase _weapon;

    private void Awake()
    {
        _weapon = transform.parent.GetComponentInChildren<WeaponBase>();
    }

    protected override void StartUse()
    {
        RoomManager.Instance.OnRoomEnter.AddListener(UseItem);
        IncreaseDamage();
    }

    protected override void UseItem()
    {
        if (_itemData.UsesCount > 0)
        {
            _itemData.UsesCount--;
            return;
        }

        RoomManager.Instance.OnRoomEnter.RemoveListener(UseItem);
        DecreaseDamage();
        Destroy(this);
    }

    private void IncreaseDamage()
    {
        var data = _itemData as DamageIncreaseAmuletData;
        foreach (var type in _weapon.AttackTypes)
            _weapon.GetAttackData(type).Damage *= data.IncreaseDamage;
    }

    private void DecreaseDamage()
    {
        var data = _itemData as DamageIncreaseAmuletData;
        foreach (var type in _weapon.AttackTypes)
            _weapon.GetAttackData(type).Damage /= data.IncreaseDamage;
    }
}

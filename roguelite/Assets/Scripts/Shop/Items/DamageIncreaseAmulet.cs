public class DamageIncreaseAmulet : Item
{
    private WeaponBase _weapon;

    private void Awake()
    {
        _weapon = transform.parent.GetComponentInChildren<WeaponBase>();
    }

    protected override void Start()
    {
        RoomManager.Instance.OnRoomEnter.AddListener(UseItem);
        IncreaseDamage();
    }

    protected override void UseItem()
    {
        if (_usesCount > 0)
        {
            _usesCount--;
            return;
        }

        RoomManager.Instance.OnRoomEnter.RemoveListener(UseItem);
        DecreaseDamage();
        Destroy(this);
    }

    private void IncreaseDamage()
    {
        foreach (var type in _weapon.AttackTypes)
            _weapon.GetAttackData(type).Damage *= _data.IncreaseDamage;
    }

    private void DecreaseDamage()
    {
        foreach (var type in _weapon.AttackTypes)
            _weapon.GetAttackData(type).Damage /= _data.IncreaseDamage;
    }
}

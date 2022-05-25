using UnityEngine;

public abstract class MoneyDropperRoom : ItemDropperRoomBase
{
    protected MoneyWallet _wallet;

    protected virtual void Awake()
    {
        _itemsCount = Random.Range(1, 10);
    }
}

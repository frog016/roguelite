using UnityEngine;

public abstract class MoneyDropperRoom : ItemDropperRoomBase
{
    protected MoneyWallet _wallet;

    protected virtual void Awake()
    {
        ItemsCount = Random.Range(1, 10);
        ItemName = $"{ItemsCount} ";
    }
}

using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected ItemData _itemData;

    public void Initialize(ItemData data)
    {
        _itemData = data;
        StartUse();
    }

    protected virtual void StartUse()
    {
        UseItem();
    }

    protected abstract void UseItem();
}

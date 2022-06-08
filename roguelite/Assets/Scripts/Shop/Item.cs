using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemData _data;

    protected int _usesCount;

    public void Initialize(ItemData data)
    {
        _data = data;
        _usesCount = data.UsesCount;
        StartUse();
    }

    protected virtual void StartUse()
    {
        UseItem();
    }

    protected abstract void UseItem();
}

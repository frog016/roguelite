using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemData _data;

    protected int _usesCount;

    protected virtual void Start()
    {
        UseItem();
    }

    public void Initialize(ItemData data)
    {
        _data = data;
        _usesCount = data.UsesCount;
    }

    protected abstract void UseItem();
}

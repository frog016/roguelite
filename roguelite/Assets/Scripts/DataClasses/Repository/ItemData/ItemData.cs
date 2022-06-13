using UnityEngine;

public abstract class ItemData : ScriptableData
{
    [SerializeField] protected int _usesCount;
    [SerializeField] protected ItemInfo _info;

    public int UsesCount { get => _usesCount; set => _usesCount = value; }
    public ItemInfo Info => _info;

    protected virtual void Initialize(int usesCount, ItemInfo info)
    {
        _usesCount = usesCount;
        _info = info;
    }
}

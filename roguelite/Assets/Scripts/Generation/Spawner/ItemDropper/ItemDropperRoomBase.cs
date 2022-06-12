using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    public ItemDropperData ItemDropperData { get; protected set; }

    protected virtual void Awake()
    {
        FindItemData();
    }

    public abstract void DropItems();

    protected abstract void FindItemData();
}

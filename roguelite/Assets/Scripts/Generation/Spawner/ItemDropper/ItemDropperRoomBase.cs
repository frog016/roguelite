using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour, IInitializable
{
    public ItemDropperData ItemDropperData { get; protected set; }

    protected virtual void Awake()
    {
        Initialize();
    }

    public abstract void DropItems();

    public abstract void Initialize();
}

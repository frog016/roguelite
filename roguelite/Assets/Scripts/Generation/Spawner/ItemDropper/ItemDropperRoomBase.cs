using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    public int ItemsCount { get; set; }
    public string ItemName { get; protected set; }

    public abstract void DropItems();
}

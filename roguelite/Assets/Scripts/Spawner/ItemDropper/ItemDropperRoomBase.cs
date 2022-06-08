using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    public int ItemsCount { get; set; }
    
    public abstract void DropItems();
}

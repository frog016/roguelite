using System;
using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    protected int _itemsCount;
    
    public abstract void DropItems();
}

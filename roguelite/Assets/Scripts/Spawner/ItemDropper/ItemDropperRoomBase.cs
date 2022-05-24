using System;
using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    protected int _itemsCount;
    protected Type _droppableItemType;

    public abstract void DropItems();
}

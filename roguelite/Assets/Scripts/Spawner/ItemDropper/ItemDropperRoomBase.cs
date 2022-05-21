using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropperRoomBase : MonoBehaviour
{
    protected int _itemsCount;
    protected Type _droppableItemType;

    public abstract List<Type> DropItems();
}

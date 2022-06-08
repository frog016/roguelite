using System;
using UnityEngine;

public class ItemBag : MonoBehaviour
{
    public void AddItem(Type type, ItemData data)
    {
        var item = gameObject.AddComponent(type) as Item;
        item.Initialize(data);
    }
}

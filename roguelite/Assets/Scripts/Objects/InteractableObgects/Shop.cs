using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : InteractableObject
{
    public List<Type> ItemTypes { get; private set; }

    private void Awake()
    {
        var itemType = typeof(Item);
        ItemTypes = itemType.Assembly.ExportedTypes
            .Where(type => itemType.IsAssignableFrom(type) && !type.IsAbstract)
            .ToList();
    }

    public override void Interaction()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        ShopPanel.Instance.OpenPanel(this);
    }

    public bool TryBuyItem(ItemDataInfo data, Type type)
    {
        if (!WalletsRepository.Instance.FindDataByType<GoldenMoneyWallet>().TrySpendMoney(data.Cost))
            return false;

        var item = PlayerSpawner.Instance.Player.GetComponentInChildren<ItemBag>().gameObject.AddComponent(type) as Item;
        item?.Initialize(data);

        return true;
    }
}

using System;
using Database.MutableDatabases;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : CardPanel<ShopPanel>
{
    protected override void GenerateCards(InteractableObject interactableObject)
    {
        _isOpened = true;

        var shop = interactableObject as Shop;
        foreach (var type in shop.ItemTypes.GetRandomItems(3))
        {
            var card = Instantiate(_cardPrefab, _cardList.transform);
            card.GetComponent<Card>().LoadInfo(GetItemData(type));

            var button = card.GetComponentInChildren<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => UseCard(shop, type, card));
        }
    }

    private void UseCard(Shop shop, Type itemType, GameObject card)
    {
        if (!shop.TryBuyItem(GetItemData(itemType), itemType))
            return;

        Destroy(card);
    }

    private ItemDataInfo GetItemData(Type type)
    {
        return ItemDatabase.Instance.GetDataByType(type);
    }
}

using System;
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
            card.GetComponent<Card>().LoadInfo(GetItemData(type).Info);

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

    private ItemData GetItemData(Type type)
    {
        return ItemDataRepository.Instance.FindDataByAssociatedType(type);
    }
}

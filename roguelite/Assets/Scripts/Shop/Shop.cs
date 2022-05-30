using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : SingletonObject<Shop>   
{
    [SerializeField] private GameObject _itemCardPrefab;
    [SerializeField] private GameObject _cardList;

    private float _step;
    private List<Type> _itemTypes;
    private ItemBag _bag;

    protected override void Awake()
    {
        base.Awake();
        _step = _itemCardPrefab.GetComponent<RectTransform>().rect.size.x + 65f;
        var itemType = typeof(Item);
        _itemTypes = itemType.Assembly.ExportedTypes
            .Where(type => itemType.IsAssignableFrom(type) && !type.IsAbstract)
            .ToList();
    }

    private void Start()
    {
        LevelGenerationManager.Instance.OnEndGeneration.AddListener(() =>
        {
            _bag = PlayerSpawner.Instance.Player.GetComponentInChildren<ItemBag>();
        });
        gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        PauseManager.Instance.Stop();
        gameObject.SetActive(true);
        ShowCards();
    }

    public void ClosePanel()
    {
        PauseManager.Instance.Continue();
        gameObject.SetActive(false);
        //_cards.ForEach(Destroy);
        //_cards = new List<GameObject>();
    }

    private void ShowCards()
    {
        var position = new Vector2(-_step, 0);
        foreach (var itemType in _itemTypes.GetRandomItems(3))
        {
            var card = Instantiate(_itemCardPrefab, _cardList.transform);
            LoadInfo(card, itemType);
            var button = card.GetComponentInChildren<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (!TryBuyItem(itemType))
                    return;

                Destroy(card);
            });
            card.GetComponent<RectTransform>().anchoredPosition = position;
            position.x += _step;
        }
    }

    private bool TryBuyItem(Type itemType)
    {
        var data = GetItemData(itemType);
        if (!WalletsManager.Instance.FindWallet<GoldenMoneyWallet>().TrySpendMoney(data.Cost))
            return false;

        var item = _bag.gameObject.AddComponent(itemType) as Item;
        item.Initialize(data);

        return true;
    }

    private void LoadInfo(GameObject card, Type type)   //  TODO: Доделать
    {
        var data = GetItemData(type);
        var image = card.GetComponentInChildren<Image>();
        image.GetComponentInChildren<Image>().sprite = data.Sprite;
        image.GetComponentInChildren<Image>().SetNativeSize();
        card.GetComponentInChildren<TextMeshProUGUI>().text = data.Description;
    }

    private ItemDataInfo GetItemData(Type type)
    {
        return ItemDatabase.Instance.GetDataByType(type);
    }
}

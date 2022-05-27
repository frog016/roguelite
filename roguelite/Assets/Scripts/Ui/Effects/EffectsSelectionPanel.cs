using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectsSelectionPanel : SingletonObject<EffectsSelectionPanel>
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private GameObject _cardList;

    private Type _currentType;
    private EffectsAltar _altar;
    private List<GameObject> _cards;

    protected override void Awake()
    {
        base.Awake();
        _cards = new List<GameObject>();
        GetComponentInChildren<Button>().onClick.AddListener(() => CreateSelectedEffect(_altar));
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        _altar = FindObjectOfType<EffectsAltar>();
        var delta = _cardPrefab.GetComponent<RectTransform>().rect.size.y;
        var position = new Vector2(0, delta);

        foreach (var type in  _altar.Types)
        {
            var card = Instantiate(_cardPrefab, _cardList.transform);
            card.GetComponent<RectTransform>().anchoredPosition = position;
            card.GetComponent<Button>().onClick.RemoveAllListeners();
            card.GetComponent<Button>().onClick.AddListener(() => ChooseEffect(type, card));
            LoadInfo(card, type);
            _cards.Add(card);
            position.y -= delta;
        }

        PauseManager.Instance.Stop();
        gameObject.SetActive(true);
    }

    private void LoadInfo(GameObject card, Type type)
    {
        var data = GetEffectData(type);
        var images = card.GetComponentsInChildren<Image>();
        images.Last().sprite = data.Sprite;
        card.GetComponentInChildren<TextMeshProUGUI>().text = data.Description;
    }

    private void ChooseEffect(Type type, GameObject card)
    {
        _currentType = type;
        card.GetComponent<Image>().color = Color.white;
        foreach (var c in _cards.Where(c => c != card))
            c.GetComponent<Image>().color = Color.black;
    }

    private void CreateSelectedEffect(EffectsAltar altar)
    {
        PlayerSpawner.Instance.Player.GetComponentInChildren<EffectsList>().AddOrUpdate(_currentType);
        PauseManager.Instance.Continue();
        Destroy(altar.gameObject);
        _cards.ForEach(Destroy);
        _cards = new List<GameObject>();
        gameObject.SetActive(false);
    }

    private EffectDataInfo GetEffectData(Type type)
    {
        return EffectsDatabase.Instance.GetDataByType(type);
    }
}
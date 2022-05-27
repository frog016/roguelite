using System;
using System.Linq;
using Database.MutableDatabases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectsInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    private float _step;
    private Vector2 _position;

    private void Awake()
    {
        _step = _cardPrefab.GetComponent<RectTransform>().rect.size.y;
        _position = new Vector2(0, 1.5f * _step);
    }

    private void Start()
    {
        LevelGenerationManager.Instance.OnEndGeneration.AddListener(() =>
        {
            var effectsList = PlayerSpawner.Instance.Player.GetComponentInChildren<EffectsList>();
            effectsList.OnEffectAddedEvent.AddListener(AddEffectCard);
        });
    }

    private void AddEffectCard(EffectData data)
    {
        var dataInfo = data as EffectDataInfo;
        var card = Instantiate(_cardPrefab, transform);
        card.GetComponent<RectTransform>().anchoredPosition = _position;
        _position.y -= _step;

        LoadInfo(card, dataInfo);
    }

    private void LoadInfo(GameObject card, EffectDataInfo data)
    {
        var images = card.GetComponentsInChildren<Image>();
        images.Last().sprite = data.Sprite;
        card.GetComponentInChildren<TextMeshProUGUI>().text = data.Description;
    }
}

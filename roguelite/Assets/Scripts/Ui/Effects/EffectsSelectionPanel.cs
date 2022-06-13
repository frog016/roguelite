using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine;
using UnityEngine.UI;

public class EffectsSelectionPanel : CardPanel<EffectsSelectionPanel>
{
    private Type _chosenEffect;
    private List<GameObject> _cards;

    protected override void Awake()
    {
        base.Awake();

        _cards = new List<GameObject>();
    }

    protected override void GenerateCards(InteractableObject interactableObject)
    {
        _isOpened = true;
        var altar = interactableObject as EffectsAltar;

        var closeButton = GetComponentInChildren<Button>();
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() => CreateSelectedEffect(altar));

        foreach (var type in altar.EffectTypes
                     .Where(eff => !PlayerSpawner.Instance.Player.GetComponentInChildren<EffectList>().Effects
                         .Select(effa => effa.GetType())
                         .Contains(eff))
                     .GetRandomItems(4))
        {
            var card = Instantiate(_cardPrefab, _cardList.transform);
            card.GetComponent<Card>().LoadInfo(GetEffectData(type));
            _cards.Add(card);

            var button = card.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => ChooseEffect(type, card));
        }
    }

    private void ChooseEffect(Type type, GameObject card)
    {
        _chosenEffect = type;
        card.GetComponent<Image>().color = Color.white;
        foreach (var otherCard in _cards.Where(c => c != card))
            otherCard.GetComponent<Image>().color = Color.black;
    }

    private void CreateSelectedEffect(EffectsAltar altar)
    {
        altar.CreateEffect(_chosenEffect);

        _cards.ForEach(Destroy);
        _cards = new List<GameObject>();

        _isOpened = false;
        ClosePanel();
    }

    private EffectInfo GetEffectData(Type type)
    {
        return EffectDataRepository.Instance.FindDataByAssociatedType(type).Info;
    }
}
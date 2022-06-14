using TMPro;
using UnityEngine;

public class EffectsInfoPanel : CardPanel<EffectsInfoPanel>
{
    [SerializeField] private TextMeshProUGUI _placeholder;

    protected override void Start()
    {
        LevelGenerationManager.Instance.OnGenerationEndedEvent.AddListener(() =>
        {
            var effectsList = PlayerSpawner.Instance.Player.GetComponentInChildren<EffectList>();
            effectsList.OnListUpdated.AddListener(AddEffectCard);
            _placeholder.gameObject.SetActive(false);
        });
    }

    protected override void GenerateCards(InteractableObject interactableObject)
    {
    }

    private void AddEffectCard(EffectBase effect)
    {
        var card = Instantiate(_cardPrefab, _cardList.transform);
        card.GetComponent<Card>().LoadInfo(effect.EffectData.Info);
    }
}

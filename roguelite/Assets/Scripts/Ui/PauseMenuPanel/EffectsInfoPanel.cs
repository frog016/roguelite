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
            effectsList.OnEffectAddedEvent.AddListener(AddEffectCard);
            _placeholder.gameObject.SetActive(false);
        });
    }

    protected override void GenerateCards(InteractableObject interactableObject)
    {
    }

    private void AddEffectCard(EffectData data)
    {
        var card = Instantiate(_cardPrefab, transform);
        card.GetComponent<Card>().LoadInfo(data.Info);
    }
}

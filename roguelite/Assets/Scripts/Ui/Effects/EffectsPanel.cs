using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EffectsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _effectCardPrefab;

    private float _angle;
    private EffectsList _effectsList;

    private void Awake()
    {
        _angle = -100 * Mathf.PI / 360;
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
        var size = _effectCardPrefab.GetComponent<RectTransform>().rect.size.x;
        var card = Instantiate(_effectCardPrefab, transform);
        card.GetComponent<RectTransform>().anchoredPosition = CalculateNextPoint(size);
        card.GetComponentsInChildren<Image>().Last().sprite = dataInfo.Sprite;
    }

    private Vector2 CalculateNextPoint(float cardSize)
    {
        var vector = new Vector2(-GetComponent<RectTransform>().rect.size.x / 2 - cardSize / 2, 0);
        var x = Mathf.Cos(_angle) * vector.x - Mathf.Sin(_angle) * vector.y;
        var y = Mathf.Sin(_angle) * vector.x + Mathf.Cos(_angle) * vector.y;
        _angle += (100 * Mathf.PI / 720);
        
        return new Vector2(x, y);
    }
}

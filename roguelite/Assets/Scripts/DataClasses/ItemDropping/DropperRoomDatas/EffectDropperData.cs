using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/ItemDroppers/EffectDropperData", fileName = "EffectDropperData")]
public class EffectDropperData : ItemDropperData
{
    [SerializeField] private int _effectsCount;
    [SerializeField] private GameObject _altarPrefab;

    public int EffectsCount => _effectsCount;
    public GameObject AltarPrefab => _altarPrefab;
}

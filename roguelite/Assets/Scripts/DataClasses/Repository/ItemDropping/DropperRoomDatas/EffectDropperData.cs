using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/ItemDroppers/EffectDropperData", fileName = "EffectDropperData")]
public class EffectDropperData : ItemDropperData
{
    [SerializeField] private int _effectsCount;
    [SerializeField] private GameObject _altarPrefab;

    public int EffectsCount => _effectsCount;
    public GameObject AltarPrefab => _altarPrefab;

    protected void Initialize(float droppingChance, string resultDescription, int effectsCount, GameObject altarPrefab)
    {
        base.Initialize(droppingChance, resultDescription);
        _effectsCount = effectsCount;
        _altarPrefab = altarPrefab;
    }

    public override Type GetAssociatedObjectType()
    {
        return typeof(EffectDropperRoom);
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<EffectDropperData>();
        copy.Initialize(_droppingChance, _resultDescription, _effectsCount, _altarPrefab);
        return copy;
    }
}

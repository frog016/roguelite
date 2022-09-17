using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/EffectData/ChainLightningEffectData", fileName = "ChainLightningEffectData")]
public class ChainLightningEffectData : EffectData
{
    [SerializeField] private int _maxChainLinksNumber;
    [SerializeField] private float _chainLinkDamage;
    [SerializeField] private float _areaRadius;

    public int MaxChainLinks => _maxChainLinksNumber;
    public float ChainLinksDamage => _chainLinkDamage;
    public float AreaRadius => _areaRadius;

    public override Type GetAssociatedObjectType()
    {
        return typeof(ChainLightningEffect);
    }

    public override ScriptableData Copy()
    {
        return this;
    }
}
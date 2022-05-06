using System.Collections.Generic;
using UnityEngine;

public class ChainLightningEffect : Effect, IEffect
{
    private List<GameObject> ChainLinks;
    private int _maxChainLinks;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _maxChainLinks = data.MaxChainLinks;

        ChainLinks = new List<GameObject>();
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in targets)
            target.ApplyDamage(_parameters.Damage);
    }

    public void MakeChain()
    {

    }
}

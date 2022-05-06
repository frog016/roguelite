using System.Collections.Generic;
using UnityEngine;

public class ChainLightningEffect : Effect, IEffect
{
    private AttackData _parameters;
    private float _procProbability;
    private List<GameObject> ChainLinks;
    private int _maxChainLinks;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _maxChainLinks = data.MaxChainLinks;
        ChainLinks = new List<GameObject>();
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        target.ApplyDamage(_parameters.Damage);

    }

    public void MakeChain()
    {

    }
}

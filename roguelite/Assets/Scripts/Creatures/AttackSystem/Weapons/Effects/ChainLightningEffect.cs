using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightningEffect : MonoBehaviour, IEffect
{
    private bool _isEvolved;
    private AttackParameters _parameters;
    private float _procProbability;
    private List<GameObject> ChainLinks;
    private int _maxChainLinks;

    public ChainLightningEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _isEvolved = data.IsEvolved;
        ChainLinks = new List<GameObject>();
        _maxChainLinks = data.MaxChainLinks;
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

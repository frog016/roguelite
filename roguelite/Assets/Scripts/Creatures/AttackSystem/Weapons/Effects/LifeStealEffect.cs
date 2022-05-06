using System.Collections.Generic;
using UnityEngine;

public class LifeStealEffect : Effect, IEffect
{
    private float _lifeStealAmount;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _lifeStealAmount = data.LifeStealAmount;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        IncreaseHealthPoints();
        StealPowerDamage(targets);
    }

    private void IncreaseHealthPoints()
    {
        
        //_player.GetComponent<DamageableObject>()._health += _lifestealAmount;
    }

    private void StealPowerDamage(List<DamageableObject> targets)
    {

    }
}

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
        IncreaseHealthPoints(targets);
    }

    private void IncreaseHealthPoints(List<DamageableObject> targets)
    {
<<<<<<< HEAD
        GetComponentInParent<GameObject>().GetComponentInParent<DamageableObject>().Health += _lifeStealAmount * targets.Count;
=======
        GetComponentInParent<Weapon>().GetComponentInParent<DamageableObject>().Health += _lifeStealAmount * targets.Count;
>>>>>>> weapon-effects
    }
}

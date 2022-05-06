using System.Collections.Generic;
using UnityEngine;

public class AirEffect : Effect, IEffect
{
    private float _knockBackForce;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _knockBackForce = data.KnockBackForce;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        ApplyDamage(targets);
    }

    private void ApplyDamage(List<DamageableObject> targets)
    {
        foreach (var target in targets)
        {
            target.ApplyDamage(_parameters.Damage);
            KnockBack(target);
        }
    }

    private void KnockBack(DamageableObject target)
    {
        target.GetComponent<Rigidbody2D>().
            AddForce((transform.parent.parent.position - target.transform.position) * _knockBackForce,
                ForceMode2D.Impulse);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class AirEffect : EffectBase
{
    private float _knockBackForce;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _knockBackForce = data.KnockBackForce;
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        ApplyDamage(attackEventArgs.DamagedTargets);
    }

    private void ApplyDamage(List<DamageableObject> targets)
    {
        foreach (var target in targets)
        {
            target.ApplyDamage(_parameters.Damage);
            if (target.Health <= 0)
                continue;

            KnockBack(target);
        }
    }

    private void KnockBack(DamageableObject target)
    {
        target.GetComponent<Rigidbody2D>().
            AddForce(-(transform.position - target.transform.position) * _knockBackForce,
                ForceMode2D.Impulse);
    }
}

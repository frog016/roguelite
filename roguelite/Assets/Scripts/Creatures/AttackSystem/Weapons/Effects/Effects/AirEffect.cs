using System.Linq;
using UnityEngine;

public class AirEffect : EffectBase
{
    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability) || attackEventArgs.DamagedTargets.Count <= 0)
            return;

        PlayVisualEffect(attackEventArgs.DamagedTargets.First().transform);
        foreach (var target in attackEventArgs.DamagedTargets)
        {
            target.ApplyDamage(EffectData.Damage);
            if (target.Health <= 0)
                continue;

            KnockBack(target);
        }
    }

    private void KnockBack(DamageableObject target)
    {
        var data = EffectData as AirEffectData;
        target.GetComponent<Rigidbody2D>().
            AddForce(-(transform.position - target.transform.position) * data.KnockBackForce,
                ForceMode2D.Impulse);
    }
}

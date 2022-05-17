using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : Effect, IEffect
{
    private List<DamageableObject> TargetsUnderEffect;
<<<<<<< HEAD

=======
>>>>>>> weapon-effects
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        TargetsUnderEffect = new List<DamageableObject>();
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;
<<<<<<< HEAD
        StartCoroutine(ApplyDamageOverTime(targets));
=======

        foreach (var target in targets)
        {
            if(!TargetsUnderEffect.Contains(target))
                StartCoroutine(ApplyDamageOverTime(target));
        }
>>>>>>> weapon-effects
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        TargetsUnderEffect.Add(target);
        var counter = 0;
        while (counter < _duration)
        {
<<<<<<< HEAD
            foreach (var target in targets)
            {
                if (!TargetsUnderEffect.Contains(target))
                {
                    target.ApplyDamage(_parameters.Damage);
                    TargetsUnderEffect.Add(target);
                }
            }
=======
            target.ApplyDamage(_parameters.Damage);

>>>>>>> weapon-effects
            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }

<<<<<<< HEAD
        targets.ForEach(x => TargetsUnderEffect.Remove(x));
=======
        TargetsUnderEffect.Remove(target);
>>>>>>> weapon-effects
    }
}

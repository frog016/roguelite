using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : Effect, IEffect
{
    private Dictionary<DamageableObject, Coroutine> Stuns;
    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in targets)
            target.ApplyDamage(_parameters.Damage);

        foreach (var target in targets)
        {
            if (Stuns.ContainsKey(target))
            {
                StopCoroutine(Stuns[target]);
                Stuns.Remove(target);
            }
            Stuns.Add(target, StartCoroutine(Stun(target)));
        }
    }

    public IEnumerator Stun(DamageableObject target)
    {
        //target.GetComponent<EnemyMoveController>().
        yield return new WaitForSeconds(_duration);
    }
}

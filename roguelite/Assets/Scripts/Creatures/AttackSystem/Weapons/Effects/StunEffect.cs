using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : Effect, IEffect
{
    private Dictionary<DamageableObject, Coroutine> _stuns;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
        _stuns = new Dictionary<DamageableObject, Coroutine>();
    }

    public void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        foreach (var target in attackEventArgs.DamagedTargets)
        {
            target.ApplyDamage(_parameters.Damage);
            if (target.Health <= 0)
                continue;

            if (_stuns.ContainsKey(target))
            {
                StopCoroutine(_stuns[target]);
                _stuns.Remove(target);
            }

            _stuns.Add(target, StartCoroutine(StunTarget(target)));
        }
    }

    private IEnumerator StunTarget(DamageableObject target)
    {
        var components = new List<MonoBehaviour>
        {
            target.GetComponent<MoveController>(),
            target.GetComponentInChildren<Weapon>()
        };

        SetEnabled(components, false);
        yield return new WaitForSeconds(_duration);
        SetEnabled(components, true);
    }

    private void SetEnabled(List<MonoBehaviour> components, bool state)
    {
        foreach (var component in components)
            component.enabled = state;
    }
}

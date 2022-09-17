using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StunEffect : EffectBase
{
    private Dictionary<DamageableObject, Coroutine> _stuns;

    public override void Initialize(EffectData data)
    {
        base.Initialize(data);
        _stuns = new Dictionary<DamageableObject, Coroutine>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability))
            return;

        foreach (var target in attackEventArgs.DamagedTargets)
        {
            target.ApplyDamage(EffectData.Damage);
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
            target.GetComponentInChildren<WeaponBase>()
        };

        PlayVisualEffect(target.transform);
        SetEnabled(components, false);
        yield return new WaitForSeconds(EffectData.Duration);
        SetEnabled(components, true);
    }

    private void SetEnabled(List<MonoBehaviour> components, bool state)
    {
        foreach (var component in components.Where(component => component != null))
            component.enabled = state;
    }
}

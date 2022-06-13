using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackSpeedEffect : EffectBase
{
    private int _stacksCount;
    private List<Cooldown> _cooldowns;

    public override void Initialize(EffectData data)
    {
        base.Initialize(data);
        _stacksCount = 0;
        _cooldowns = transform.parent.GetComponentsInChildren<Cooldown>().ToList();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability) || attackEventArgs.DamagedTargets.Count <= 0)
            return;

        var data = EffectData as AttackSpeedEffectData;
        foreach (var cooldown in _cooldowns)
            cooldown.CooldownTime = 
                cooldown.InitialCooldown * data.IncreasedAttackSpeedCoefficient * 
                Math.Min(attackEventArgs.DamagedTargets.Count, data.MaxStackNumber - _stacksCount);
        
        StopAllCoroutines();
        StartCoroutine(DropStacks());
    }

    private IEnumerator DropStacks()
    {
        yield return new WaitForSeconds(EffectData.Damage);

        var data = EffectData as AttackSpeedEffectData;
        while (_stacksCount > 0)
        {
            _stacksCount--;
            foreach (var cooldown in _cooldowns)
                cooldown.CooldownTime += cooldown.InitialCooldown * data.IncreasedAttackSpeedCoefficient;

            yield return new WaitForSeconds(1f);
        }

    }
}

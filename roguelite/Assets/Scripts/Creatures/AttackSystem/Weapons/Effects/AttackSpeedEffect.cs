using System;
using System.Collections;
using UnityEngine;

public class AttackSpeedEffect : Effect, IEffect
{
    private int _maxStacks;
    private int _stacksCount;
    private float _increasedAttackSpeedCoefficient;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
        _increasedAttackSpeedCoefficient = data.IncreasedAttackSpeedCoefficient;
    }

    public void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        var cooldowns = GetComponentsInParent<Cooldown>();
        foreach (var cooldown in cooldowns)
            cooldown.CooldownTime = 
                cooldown.InitialCooldown * _increasedAttackSpeedCoefficient * 
                Math.Min(attackEventArgs.DamagedTargets.Count, _maxStacks - _stacksCount);
        
        StopAllCoroutines();
        StartCoroutine(DropStacks(cooldowns));
    }

    private IEnumerator DropStacks(Cooldown[] cooldowns)
    {
        yield return new WaitForSeconds(_duration);

        while (_stacksCount > 0)
        {
            _stacksCount--;
            foreach (var cooldown in cooldowns)
                cooldown.CooldownTime += cooldown.InitialCooldown * _increasedAttackSpeedCoefficient;

            yield return new WaitForSeconds(1f);
        }

    }
}

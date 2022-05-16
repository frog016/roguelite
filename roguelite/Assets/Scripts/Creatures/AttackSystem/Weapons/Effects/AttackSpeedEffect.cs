using System;
using System.Collections;
using System.Collections.Generic;
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

    public void ApplyEffect(List<DamageableObject> targets)
    {
        var Cooldowns = GetComponentsInParent<Cooldown>();
        Cooldowns[0].CooldownTime -= Cooldowns[0].InitialCooldown * _increasedAttackSpeedCoefficient * Math.Min(targets.Count, _maxStacks - _stacksCount);
        Cooldowns[1].CooldownTime -= Cooldowns[1].InitialCooldown * _increasedAttackSpeedCoefficient * Math.Min(targets.Count, _maxStacks - _stacksCount);
        StopAllCoroutines();

        DropStacks(Cooldowns);
    }

    private IEnumerator DropStacks(Cooldown[] Cooldowns)
    {
        yield return new WaitForSeconds(_duration);
        while (_stacksCount > 0)
        {
            _stacksCount--;
            Cooldowns[0].CooldownTime += Cooldowns[0].InitialCooldown * _increasedAttackSpeedCoefficient;
            Cooldowns[1].CooldownTime += Cooldowns[1].InitialCooldown * _increasedAttackSpeedCoefficient;
            yield return new WaitForSeconds(1f);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedEffect : Effect, IEffect
{
    private int _maxStacks;
    private int _stacksCount;
<<<<<<< HEAD
    private float _increasedAttackSpeedCoefficient;
=======
    private float _increasedAttackSpeedÑoeff;
>>>>>>> weapon-effects

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
<<<<<<< HEAD
        _increasedAttackSpeedCoefficient = data.IncreasedAttackSpeedCoefficient;
=======
        _increasedAttackSpeedÑoeff = data.IncreasedAttackSpeedÑoeff;
>>>>>>> weapon-effects
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        var Cooldowns = GetComponentsInParent<Cooldown>();
<<<<<<< HEAD
        Cooldowns[0].CooldownTime -= Cooldowns[0].InitialCooldown * _increasedAttackSpeedCoefficient * Math.Min(targets.Count, _maxStacks - _stacksCount);
        Cooldowns[1].CooldownTime -= Cooldowns[1].InitialCooldown * _increasedAttackSpeedCoefficient * Math.Min(targets.Count, _maxStacks - _stacksCount);
=======
        Cooldowns[0].CooldownTime -= Cooldowns[0].InitialCooldown * _increasedAttackSpeedÑoeff * Math.Min(targets.Count, _maxStacks - _stacksCount);
        Cooldowns[1].CooldownTime -= Cooldowns[1].InitialCooldown * _increasedAttackSpeedÑoeff * Math.Min(targets.Count, _maxStacks - _stacksCount);
>>>>>>> weapon-effects
        StopAllCoroutines();

        DropStacks(Cooldowns);
    }

    private IEnumerator DropStacks(Cooldown[] Cooldowns)
    {
        yield return new WaitForSeconds(_duration);
        while (_stacksCount > 0)
        {
            _stacksCount--;
<<<<<<< HEAD
            Cooldowns[0].CooldownTime += Cooldowns[0].InitialCooldown * _increasedAttackSpeedCoefficient;
            Cooldowns[1].CooldownTime += Cooldowns[1].InitialCooldown * _increasedAttackSpeedCoefficient;
=======
            Cooldowns[0].CooldownTime += Cooldowns[0].InitialCooldown * _increasedAttackSpeedÑoeff;
            Cooldowns[1].CooldownTime += Cooldowns[1].InitialCooldown * _increasedAttackSpeedÑoeff;
>>>>>>> weapon-effects
            yield return new WaitForSeconds(1f);
        }

    }
}

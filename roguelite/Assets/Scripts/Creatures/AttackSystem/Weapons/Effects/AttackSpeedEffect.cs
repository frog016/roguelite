using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedEffect : Effect, IEffect
{
    private int _maxStacks;
    private int _stacksCount;
    private float _increasedAttackSpeed—oeff;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _duration = data.Duration;
        _maxStacks = data.MaxStacks;
        _increasedAttackSpeed—oeff = data.IncreasedAttackSpeed—oeff;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        var Cooldowns = GetComponentsInParent<Cooldown>();
        Cooldowns[0].CooldownTime -= Cooldowns[0].InitialCooldown * _increasedAttackSpeed—oeff * Math.Min(targets.Count, _maxStacks - _stacksCount);
        Cooldowns[1].CooldownTime -= Cooldowns[1].InitialCooldown * _increasedAttackSpeed—oeff * Math.Min(targets.Count, _maxStacks - _stacksCount);
        StopAllCoroutines();

        DropStacks(Cooldowns);
    }

    private IEnumerator DropStacks(Cooldown[] Cooldowns)
    {
        yield return new WaitForSeconds(_duration);
        while (_stacksCount > 0)
        {
            _stacksCount--;
            Cooldowns[0].CooldownTime += Cooldowns[0].InitialCooldown * _increasedAttackSpeed—oeff;
            Cooldowns[1].CooldownTime += Cooldowns[1].InitialCooldown * _increasedAttackSpeed—oeff;
            yield return new WaitForSeconds(1f);
        }

    }
}

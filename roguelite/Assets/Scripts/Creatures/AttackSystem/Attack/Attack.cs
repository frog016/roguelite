using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack
{
    public UnityEvent<List<DamageableObject>> OnAttack { get; protected set; }

    protected readonly AttackData _data;
    protected readonly Cooldown _cooldown;
    protected readonly TargetsFinder _targetsFinder;

    public Attack(AttackData attackData, TargetsFinder targetsFinder)
    {
        _data = attackData;
        _cooldown = attackData.Cooldown;
        _targetsFinder = targetsFinder;
    }
}

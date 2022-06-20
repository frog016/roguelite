using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlobalCooldown))]
public abstract class WeaponBase : MonoBehaviour
{
    public UnityEvent<AttackBase> OnAttackEvent { get; private set; }
    public UnityEvent OnAttackEndedEvent { get; private set; }

    public GlobalCooldown GlobalCooldown { get; private set; }
    public List<Type> AttackTypes => _attacks.Keys.ToList();

    private AttackList _attackList;
    private EffectList _effectList;
    private Dictionary<Type, AttackBase> _attacks;

    protected virtual void Awake()
    {
        OnAttackEvent = new UnityEvent<AttackBase>();
        OnAttackEndedEvent = new UnityEvent();

        _attackList = GetComponentInChildren<AttackList>();
        _attackList.LoadAttacks();
        CreateAttackMapping();

        _effectList = GetComponentInChildren<EffectList>();
    }

    public virtual void InitializeWeapon(WeaponData data)
    {
        GlobalCooldown = GetComponent<GlobalCooldown>();
        GlobalCooldown.ResetCooldownTime(data.GlobalCooldownTime);
    }

    public void UseAttack(Type attackType)
    {
        if (!CanAttack(attackType))
            return;

        var currentAttack = _attacks[attackType];
        OnAttackEvent.Invoke(currentAttack);
        currentAttack.Attack();
        GlobalCooldown.TryRestartCooldown();
    }

    public bool CanAttack(Type attackType)
    {
        return GlobalCooldown.IsReady && _attacks[attackType].IsReady();
    }

    public AttackData GetAttackData(Type attackType)
    {
        return _attacks[attackType].AttackData;
    }

    protected void ActivateEffects(AttackEventArgs attackEventArgs)
    {
        OnAttackEndedEvent.Invoke();
        foreach (var effect in _effectList.ToList())
            effect.ApplyEffect(attackEventArgs);
    }

    private void CreateAttackMapping()
    {
        _attacks = new Dictionary<Type, AttackBase>();

        foreach (var attack in _attackList)
        {
            var type = attack.GetType();
            _attacks.Add(type, attack);
            attack.OnAttackCompletedEvent.AddListener(ActivateEffects);
        }
    }
}

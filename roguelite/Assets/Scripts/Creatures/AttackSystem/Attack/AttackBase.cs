using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cooldown))]
public abstract class AttackBase : MonoBehaviour
{
    protected AttackData _attackData;
    protected Cooldown _cooldown;
    protected TargetsFinder _targetsFinder;

    public AttackData AttackData => _attackData;

    protected virtual void Awake()
    {
        _targetsFinder = GetComponentInParent<TargetsFinder>();
        _cooldown = GetComponent<Cooldown>();
    }

    public void Initialize(AttackData data)
    {
        _attackData = data;
    }

    public virtual List<DamageableObject> Attack()
    {
        return new List<DamageableObject>();
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

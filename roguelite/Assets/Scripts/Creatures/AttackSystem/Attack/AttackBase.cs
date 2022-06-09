using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cooldown))]
public abstract class AttackBase : MonoBehaviour
{
    public UnityEvent<AttackBase> OnAttackStartedEvent { get; private set; }
    public UnityEvent<AttackBase> OnAttackPreparedEvent { get; private set; }
    public UnityEvent<AttackEventArgs> OnAttackCompletedEvent { get; private set; }
    
    protected AttackData _attackData;
    protected Cooldown _cooldown;
    protected TargetsFinder _targetsFinder;

    public AttackData AttackData => _attackData;

    protected virtual void Awake()
    {
        OnAttackStartedEvent = new UnityEvent<AttackBase>();
        OnAttackPreparedEvent = new UnityEvent<AttackBase>();
        OnAttackCompletedEvent = new UnityEvent<AttackEventArgs>();

        _targetsFinder = GetComponentInParent<TargetsFinder>();
        _cooldown = GetComponent<Cooldown>();
    }

    public void Initialize(AttackData data)
    {
        _attackData = data;
        _cooldown.ResetCooldownTime(data.CooldownTime);
    }

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    protected virtual IEnumerator AttackCoroutine()
    {
        OnAttackStartedEvent.Invoke(this);
        yield return new WaitForSeconds(_attackData.DelayBeforeAttack);
        OnAttackPreparedEvent.Invoke(this);
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

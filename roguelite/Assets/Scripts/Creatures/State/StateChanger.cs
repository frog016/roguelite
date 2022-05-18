using System;
using UnityEngine;

[RequireComponent(typeof(StateHandler))]
public abstract class StateChanger : MonoBehaviour
{
    protected DamageableObject _target;
    protected StateHandler _stateHandler;

    protected virtual void Awake()
    {
        _stateHandler = GetComponent<StateHandler>();
    }

    public virtual void SetTarget(DamageableObject target)
    {
        _target = target;
    }

    protected abstract void ChangeState();

    protected bool IsOtherState(Type stateType)
    {
        return _stateHandler.CurrentState.GetType() != stateType;
    }
}

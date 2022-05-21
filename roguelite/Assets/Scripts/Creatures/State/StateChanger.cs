using System;
using UnityEngine;

[RequireComponent(typeof(StateHandler))]
public abstract class StateChanger : MonoBehaviour
{
    public StateHandler StateHandler { get; protected set; }

    protected DamageableObject _target;

    protected virtual void Awake()
    {
        StateHandler = GetComponent<StateHandler>();
    }

    public virtual void SetTarget(DamageableObject target)
    {
        _target = target;
    }

    protected abstract void ChangeState();

    protected bool IsOtherState(Type stateType)
    {
        return StateHandler.CurrentState.GetType() != stateType;
    }
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StateHandler))]
public abstract class StateChanger : MonoBehaviour
{
    public StateHandler StateHandler { get; protected set; }

    protected virtual void Awake()
    {
        StateHandler = GetComponent<StateHandler>();
    }

    protected virtual void Update()
    {
        ChangeState();
    }

    protected abstract void ChangeState();
}

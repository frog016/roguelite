using UnityEngine;
using UnityEngine.Events;

public class StateHandler : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    public UnityEvent<IState> OnStateChangedEvent { get; private set; }

    private IState _previousState;

    private void Awake()
    {
        CurrentState = new IdleState();
        OnStateChangedEvent = new UnityEvent<IState>();
    }

    private void FixedUpdate()
    {
        CurrentState.Execute();
    }

    public void SetState(IState newState)
    {
        if (!CurrentState.CanExit())
            return;

        _previousState = CurrentState;
        if (IsOtherState(newState))
            OnStateChangedEvent.Invoke(newState);

        CurrentState.Exit();
        CurrentState = newState;
    }

    public void ReturnPreviousState()
    {
        if (_previousState == null)
            return;

        CurrentState = new IdleState();
    }

    public bool IsOtherState(IState state)
    {
        return CurrentState.GetType() != state.GetType();
    }
}

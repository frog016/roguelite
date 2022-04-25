using UnityEngine;

public class StateHandler : MonoBehaviour
{
    private IState _currentState;

    private void Awake()
    {
        _currentState = new StandState();
    }

    private void FixedUpdate()
    {
        _currentState.Execute();
    }

    public void SetState(IState newState)
    {
        _currentState = newState;
    }
}

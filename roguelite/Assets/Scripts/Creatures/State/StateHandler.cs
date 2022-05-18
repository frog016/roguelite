using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    private void Awake()
    {
        CurrentState = new StandState();
    }

    private void FixedUpdate()
    {
        CurrentState.Execute();
    }

    public void SetState(IState newState)
    {
        CurrentState = newState;
    }
}

using UnityEngine;

public class WalkState : IState
{
    private readonly StateHandler _stateHandler;
    private readonly MoveController _controller;
    private readonly Vector2 _target;

    public WalkState(StateHandler stateHandler, Vector2 target)
    {
        _stateHandler = stateHandler;
        _controller = stateHandler.GetComponent<MoveController>();
        _target = target;
    }

    public void Execute()
    {
        _controller.Move(_target);
    }

    public void Exit()
    {
        _stateHandler.ReturnPreviousState();
    }

    public bool CanExit()
    {
        return true;
    }
}

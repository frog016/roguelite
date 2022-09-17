public class DashState : IState
{
    private bool _canExit;
    private readonly StateHandler _stateHandler;
    private readonly MoveController _controller;

    public DashState(StateHandler stateHandler)
    {
        _canExit = false;
        _stateHandler = stateHandler;
        _controller = stateHandler.GetComponent<MoveController>();
        _controller.OnDashEndedEvent.AddListener(ReadyToExit);
    }

    public void Execute()
    {
        _controller.Dash();
    }

    public void Exit()
    {
        _controller.OnDashEndedEvent.RemoveListener(ReadyToExit);
        _stateHandler.ReturnPreviousState();
    }

    public bool CanExit()
    {
        return _canExit;
    }

    private void ReadyToExit()
    {
        _canExit = true;
    }
}

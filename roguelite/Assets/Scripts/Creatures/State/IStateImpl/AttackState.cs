public class AttackState : IState
{
    private bool _canExit;
    private readonly StateHandler _stateHandler;
    private readonly AttackController _attackController;

    public AttackState(StateHandler stateHandler)
    {
        _canExit = false;
        _stateHandler = stateHandler;
        _attackController = stateHandler.GetComponent<AttackController>();
        _attackController.Weapon.OnAttackEndedEvent.AddListener(ReadyToExit);
    }

    public void Execute()
    {
        _attackController.HandleInput();
    }

    public void Exit()
    {
        _attackController.Weapon.OnAttackEndedEvent.RemoveListener(ReadyToExit);
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

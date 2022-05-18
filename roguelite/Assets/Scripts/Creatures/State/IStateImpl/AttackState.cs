public class AttackState : IState
{
    private readonly AttackController _attackController;

    public AttackState(AttackController attackController)
    {
        _attackController = attackController;
    }

    public void Execute()
    {
        _attackController.HandleInput();
    }
}

public interface IState
{
    void Execute();
    void Exit();
    bool CanExit();
}

using UnityEngine;

public class FollowState : IState
{
    private readonly MoveController _controller;
    private readonly GameObject _target;

    public FollowState(MoveController controller, GameObject target)
    {
        _controller = controller;
        _target = target;
    }

    public void Execute()
    {
        _controller.Move(_target.transform.position);
    }
}

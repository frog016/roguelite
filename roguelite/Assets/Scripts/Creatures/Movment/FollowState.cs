using UnityEngine;

public class FollowState : IState
{
    private readonly MoveController _owner;
    private readonly GameObject _target;

    public FollowState(MoveController owner, GameObject target)
    {
        _owner = owner;
        _target = target;
    }

    public void Execute()
    {
        var direction = (_target.transform.position - _owner.transform.position);
        _owner.Move(direction);
    }
}

using UnityEngine;
using UnityEngine.AI;

public class FollowState : IState
{
    //private readonly MoveController _owner;
    private readonly NavMeshAgent _agent;
    private readonly GameObject _target;

    public FollowState(MoveController owner, GameObject target)
    {
        //_owner = owner;
        _agent = owner.GetComponent<NavMeshAgent>();
        _target = target;
    }

    public void Execute()
    {
        //var direction = (_target.transform.position - _owner.transform.position);
        _agent.SetDestination(_target.transform.position);
        //_owner.Move(direction);
    }
}

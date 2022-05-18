using UnityEngine;
using UnityEngine.AI;

public class FollowState : IState
{
    private readonly NavMeshAgent _agent;
    private readonly GameObject _target;

    public FollowState(NavMeshAgent owner, GameObject target)
    {
        _agent = owner;
        _target = target;
    }

    public void Execute()
    {
        _agent.SetDestination(_target.transform.position);
    }
}

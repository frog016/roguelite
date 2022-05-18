using UnityEngine;
using UnityEngine.AI;

public class EnemyStateChanger : StateChanger
{
    private NavMeshAgent _agent;

    protected override void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target == null)
            return;

        ChangeState();
    }

    public override void SetTarget(DamageableObject target)
    {
        _target.OnObjectDeath.RemoveListener(SetStandState);
        base.SetTarget(target);
        _target.OnObjectDeath.AddListener(SetStandState);
        _stateHandler.SetState(new FollowState(_agent, _target.gameObject));
    }

    protected override void ChangeState()   //  TODO: Рефакторинг
    {
        var distance = Vector2.Distance(_target.transform.position, transform.position);
        if (distance < _agent.stoppingDistance)
            _stateHandler.SetState(new AttackState(GetComponent<AttackController>()));
        else
            _stateHandler.SetState(new FollowState(_agent, _target.gameObject));
    }

    private void SetStandState()
    {
        _stateHandler.SetState(new StandState());
    }
}

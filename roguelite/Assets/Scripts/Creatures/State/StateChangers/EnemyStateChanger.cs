using UnityEngine;

public class EnemyStateChanger : StateChanger
{
    private EnemyMoveController _moveController;
    private DamageableObject _target;

    protected override void Awake()
    {
        base.Awake();
        _moveController = GetComponent<EnemyMoveController>();
    }

    protected override void Update()
    {
        if (_target == null)
            return;

        ChangeState();
    }

    public void SetTarget(DamageableObject target)
    {
        _target?.OnObjectDeath.RemoveListener(SetStandState);
        _target = target;
        _target.OnObjectDeath.AddListener(SetStandState);
        StateHandler.SetState(new WalkState(StateHandler, _target.transform.position));
    }

    protected override void ChangeState()
    {
        var distance = Vector2.Distance(_target.transform.position, transform.position);
        IState state;

        if (distance < _moveController.Agent.stoppingDistance) 
            state = new AttackState(StateHandler);
        else
            state = new WalkState(StateHandler, _target.transform.position);

        StateHandler.SetState(state);
    }

    private void SetStandState()
    {
        StateHandler.SetState(new IdleState());
    }
}

using UnityEngine;

public class EnemyStateChanger : StateChanger
{
    private EnemyMoveController _moveController;

    protected override void Awake()
    {
        base.Awake();
        _moveController = GetComponent<EnemyMoveController>();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        ChangeState();
    }

    public override void SetTarget(DamageableObject target)
    {
        _target?.OnObjectDeath.RemoveListener(SetStandState);
        base.SetTarget(target);
        _target.OnObjectDeath.AddListener(SetStandState);
        StateHandler.SetState(new FollowState(_moveController, _target.gameObject));
    }

    protected override void ChangeState()   //  TODO: Рефакторинг
    {
        var distance = Vector2.Distance(_target.transform.position, transform.position);
        if (distance < _moveController.Agent.stoppingDistance)
            StateHandler.SetState(new AttackState(GetComponent<AttackController>()));
        else
            StateHandler.SetState(new FollowState(_moveController, _target.gameObject));
    }

    private void SetStandState()
    {
        StateHandler.SetState(new StandState());
    }
}

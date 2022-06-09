using UnityEngine;

public class PlayerStateChanger : StateChanger
{
    private PlayerAttackController _attackController;

    protected override void Awake()
    {
        base.Awake();
        _attackController = GetComponent<PlayerAttackController>();
    }

    protected override void ChangeState()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        IState state;

        if (_attackController.CanAttack("Fire1") || _attackController.CanAttack("Fire2"))
            state = new AttackState(StateHandler);
        else if (Input.GetKeyDown(KeyCode.Space))
            state = new DashState(StateHandler);
        else if (direction.sqrMagnitude > 0)
            state = new WalkState(StateHandler, direction);
        else
            state = new IdleState();

        StateHandler.SetState(state);
    }
}

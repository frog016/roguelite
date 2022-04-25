using UnityEngine;

public class AttackState : IState
{
    private readonly Weapon _owner;
    private readonly GameObject _target;

    public AttackState(MoveController owner, GameObject target)
    {
        _owner = owner.GetComponentInChildren<Weapon>();
        _target = target;
    }

    public void Execute()
    {
        _owner.CurrentWeapon.Attack();
    }
}

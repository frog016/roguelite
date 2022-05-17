using UnityEngine;

public class AttackState : IState
{
    private readonly Weapon _owner;

    public AttackState(MoveController owner)
    {
        _owner = owner.GetComponentInChildren<Weapon>();
    }

    public void Execute()
    {
        (_owner as IWeapon)?.Attack(_owner.AttackTypes[0]);
    }
}

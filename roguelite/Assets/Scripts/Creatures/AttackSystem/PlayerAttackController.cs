using UnityEngine;

public class PlayerAttackController : AttackController
{
    public override void HandleInput(AttackType attackType = default)
    {
        if (Mathf.Abs(Input.GetAxis("Fire1")) > 1e-12)
            Weapon.UseAttack(Weapon?.AttackTypes[0]);
        if (Mathf.Abs(Input.GetAxis("Fire2")) > 1e-12)
            Weapon.UseAttack(Weapon?.AttackTypes[1]);
    }

    public bool CanAttack(string axis)
    {
        var i = axis == "Fire1" ? 0 : 1;
        return Input.GetAxis(axis) > 0 && Weapon.CanAttack(Weapon?.AttackTypes[i]);
    }
}

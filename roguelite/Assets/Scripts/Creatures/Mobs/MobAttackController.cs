using System;

public class MobAttackController : AttackController
{
    public override void HandleInput(Type attackType = null)
    {
        attackType ??= Weapon.AttackTypes[0];
        Weapon.UseAttack(attackType);
    }
}

public class MobAttackController : AttackController
{
    public override void HandleInput(AttackType attackType = default)
    {
        Weapon.UseAttack(Weapon.AttackTypes[0]);
    }
}

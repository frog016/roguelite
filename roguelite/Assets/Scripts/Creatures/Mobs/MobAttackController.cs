public class MobAttackController : AttackController
{
    public override void HandleInput(AttackType attackType = default)
    {
        _weapon.UseAttack(_weapon.AttackTypes[0]);
    }
}

public class MobAttackController : AttackController
{
    public override void HandleInput(AttackType attackType = default)
    {
        _weapon.TryAttack(TypeConvertor.ConvertEnumToType(attackType));
    }
}

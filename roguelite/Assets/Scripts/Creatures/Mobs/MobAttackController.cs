public class MobAttackController : AttackController
{
    public override void HandleInput(AttackType attackType = default)
    {
        _weapon.Attack(TypeConvertor.ConvertEnumToType(attackType));
    }
}
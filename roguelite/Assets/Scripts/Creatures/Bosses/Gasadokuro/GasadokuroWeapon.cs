using System;

public class GasadokuroWeapon : Weapon, IWeapon
{
    public void Attack(Type attackType)
    {
        var currentAttack = _attacks[TypeConvertor.ConvertTypeToEnum(attackType)];
        if (!currentAttack.IsReady())
            return;

        var targets = currentAttack.Attack();
        ActivateEffects(new AttackEventArgs(currentAttack, targets));
    }
}

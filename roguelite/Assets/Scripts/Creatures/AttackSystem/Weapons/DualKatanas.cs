using System;

public class DualKatanas : Weapon, IWeapon
{
    public bool TryAttack(Type attackType)
    {
        var currentAttack = _attacks[TypeConvertor.ConvertTypeToEnum(attackType)];
        if (!GlobalCooldown.IsReady || !currentAttack.IsReady())
            return false;

        var targets = currentAttack.Attack();
        GlobalCooldown.TryRestartCooldown();
        ActivateEffects(new AttackEventArgs(currentAttack, targets));

        return true;
    }
}

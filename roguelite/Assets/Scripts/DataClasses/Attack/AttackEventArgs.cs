using System.Collections.Generic;

public class AttackEventArgs
{
    public readonly AttackBase UsedAttack;
    public readonly List<DamageableObject> DamagedTargets;

    public AttackEventArgs(AttackBase usedAttack, List<DamageableObject> damagedTargets)
    {
        UsedAttack = usedAttack;
        DamagedTargets = damagedTargets;
    }
}

using System.Collections.Generic;

public class AttackEventArgs
{
    public readonly IAttack UsedAttack;
    public readonly List<DamageableObject> DamagedTargets;

    public AttackEventArgs(IAttack usedAttack, List<DamageableObject> damagedTargets)
    {
        UsedAttack = usedAttack;
        DamagedTargets = damagedTargets;
    }
}

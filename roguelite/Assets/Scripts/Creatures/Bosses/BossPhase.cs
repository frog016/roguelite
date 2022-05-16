using System.Collections.Generic;
using UnityEngine;

public class BossPhase
{
    public readonly List<IAttack> ActiveAttacks;
    public readonly Queue<IAttack> AttacksOnCooldown;

    public BossPhase(IEnumerable<IAttack> attacks)
    {
        ActiveAttacks = new List<IAttack>(attacks);
        AttacksOnCooldown = new Queue<IAttack>();
    }

    public void Attack()
    {
        var attack = GetRandomAttack();
    }

    private IAttack GetRandomAttack()
    {
        var index = Random.Range(0, ActiveAttacks.Count);
        var attack = ActiveAttacks[index];
        ActiveAttacks.RemoveAt(index);

        return attack;
    }
}

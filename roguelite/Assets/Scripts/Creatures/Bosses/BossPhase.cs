using System.Collections.Generic;
using UnityEngine;

public class BossPhase
{
    public readonly List<IAttack> ActiveAttacks;
    public readonly HashSet<IAttack> AttacksOnCooldown;

    public BossPhase(IEnumerable<IAttack> attacks)
    {
        ActiveAttacks = new List<IAttack>(attacks);
        AttacksOnCooldown = new HashSet<IAttack>();
        RefreshQueue();
    }

    public List<DamageableObject> Attack()
    {
        var attack = GetRandomAttack();
        var targets = attack.Attack();

        ActiveAttacks.Remove(attack);
        AttacksOnCooldown.Add(attack);

        return targets;
    }

    private void RefreshQueue()
    {
        foreach (var attack in ActiveAttacks)
            (attack as Attack)?.OnAttackReady.AddListener(() => ReplaceAttack(attack));
    }

    private void ReplaceAttack(IAttack attack)
    {
        ActiveAttacks.Add(attack);
        AttacksOnCooldown.Remove(attack);
    }

    private IAttack GetRandomAttack()
    {
        var index = Random.Range(0, ActiveAttacks.Count);
        var attack = ActiveAttacks[index];
        ActiveAttacks.RemoveAt(index);

        return attack;
    }
}

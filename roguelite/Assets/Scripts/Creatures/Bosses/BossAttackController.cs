using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BossAttackController : AttackController
{
    private List<Type> _activeAttacks;

    protected override void Start()
    {
        base.Start();
        _activeAttacks = _weapon.AttackTypes;
    }

    public override void HandleInput(AttackType attackType = default)
    {
        if (!(_weapon as WeaponBase).GlobalCooldown.IsReady)
            return;

        var attack = TryGetRandomAttackType();
        if (attack == null)
            return;

        _weapon.UseAttack(attack);
    }

    private Type TryGetRandomAttackType()
    {
        var index = Random.Range(0, _activeAttacks.Count);
        while (!_weapon.IsReady(_activeAttacks[index]))
            index = Random.Range(0, _activeAttacks.Count);

        return _activeAttacks[index];
    }
}

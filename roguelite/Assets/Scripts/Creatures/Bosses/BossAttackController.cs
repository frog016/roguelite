using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BossAttackController : AttackController
{
    private List<Type> _activeAttacks;

    protected override void Start()
    {
        base.Start();
        _activeAttacks = (_weapon as Weapon).AttackTypes;
    }

    public override void HandleInput(AttackType attackType = default)
    {
        var attack = GetRandomAttackType();
        _weapon.Attack(attack);
    }

    private Type GetRandomAttackType()
    {
        var index = Random.Range(0, _activeAttacks.Count);
        while (!(_weapon as Weapon).IsReady(TypeConvertor.ConvertTypeToEnum(_activeAttacks[index])))
            index = Random.Range(0, _activeAttacks.Count);

        return _activeAttacks[index];
    }
}

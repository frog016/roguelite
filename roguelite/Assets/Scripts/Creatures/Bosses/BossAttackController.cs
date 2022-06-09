using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BossAttackController : AttackController    //  TODO: Отрефакторить, вынести получение следующей атаки в отдельный класс, и перестановку дистанции для остановки сделать через событие получения следующей атаки
{
    private EnemyMoveController _moveController;
    private Tuple<Type, AttackData> _nextAttack;
    private List<Type> _activeAttacks;

    protected override void Start()
    {
        base.Start();
        _moveController = GetComponent<EnemyMoveController>();
        _activeAttacks = Weapon.AttackTypes;
        _nextAttack = TryGetRandomAttack();
    }

    public override void HandleInput(AttackType attackType = default)
    {
        if (!Weapon.GlobalCooldown.IsReady || _nextAttack == null)
            return;

        Weapon.UseAttack(_nextAttack.Item1);
        _nextAttack = TryGetRandomAttack();
        _moveController.Agent.stoppingDistance = _nextAttack.Item2.AttackRadius;
    }

    private Tuple<Type, AttackData> TryGetRandomAttack()
    {
        var index = Random.Range(0, _activeAttacks.Count);
        var type = _activeAttacks[index];
        
        return Tuple.Create(type, Weapon.GetAttackData(type)); ;
    }
}

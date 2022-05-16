using System.Collections.Generic;

public class SummonAcolytes : Attack, IAttack
{
    public SummonAcolytes(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
    }

    public List<DamageableObject> Attack()
    {
        _cooldown.TryRestartCooldown();
        Spawner.Instance.SpawnUnits(CreateAcolytesData());

        return new List<DamageableObject>();
    }

    private SpawnData CreateAcolytesData()
    {
        var data = new SpawnData();
        data.AddUnitsData(new SpawnUnitsData(CreatureType.SkeletonSamurai, 2));
        return data;
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }
}

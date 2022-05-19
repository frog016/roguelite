using System.Collections.Generic;

public class SummonAcolytes : AttackBase
{
    public override List<DamageableObject> Attack()
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
}

public class CriticalStrikeEffect : EffectBase
{
    private float _criticalHitCoefficient;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _criticalHitCoefficient = data.CriticalHitCoefficient;
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs) //  ������ �����������, �� ����� �����
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        var damage = (attackEventArgs.UsedAttack as AttackBase).AttackData.Damage * _criticalHitCoefficient;
        foreach (var target in attackEventArgs.DamagedTargets)
            target.ApplyDamage(damage);
    }
}

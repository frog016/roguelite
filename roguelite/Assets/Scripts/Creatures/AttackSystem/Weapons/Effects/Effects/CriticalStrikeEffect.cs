public class CriticalStrikeEffect : NegativeEffect
{
    private float _criticalHitCoefficient;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _criticalHitCoefficient = data.CriticalHitCoefficient;
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs) //  Плохая реализвация, но иначе никак
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        var damage = attackEventArgs.UsedAttack.AttackData.Damage * _criticalHitCoefficient;
        foreach (var target in attackEventArgs.DamagedTargets)
            target.ApplyDamage(damage);
    }
}

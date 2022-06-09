using UnityEngine;

public class CriticalStrikeEffect : EffectBase
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
        {
            var visualEffect = Instantiate(_visualEffect, target.transform);
            var particle = visualEffect.GetComponent<ParticleSystem>().main;
            particle.duration = _duration;
            visualEffect.GetComponent<ParticleSystem>().Play();
            target.ApplyDamage(damage);
        }
    }
}

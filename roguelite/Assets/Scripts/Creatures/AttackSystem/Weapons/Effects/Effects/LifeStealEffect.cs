using UnityEngine;

public class LifeStealEffect : EffectBase
{
    private float _lifeStealAmount;
    private DamageableObject _myHealth;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _lifeStealAmount = data.LifeStealAmount;

        _myHealth = GetComponentInParent<DamageableObject>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (attackEventArgs.DamagedTargets.Count > 0)
        {
            var visualEffect = Instantiate(_visualEffect, transform);
            var particle = visualEffect.GetComponent<ParticleSystem>().main;
            particle.duration = _duration;
            visualEffect.GetComponent<ParticleSystem>().Play();
        }

        foreach (var target in attackEventArgs.DamagedTargets)
            StealHealth(target);
    }

    private void StealHealth(DamageableObject target)
    {
        _myHealth.ApplyHeath(_lifeStealAmount);
        target.ApplyDamage(_lifeStealAmount);
    }
}

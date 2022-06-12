using System.Collections.Generic;
using Edgar.Legacy.GeneralAlgorithms.Algorithms.Common;
using UnityEngine;

//TODO: добавить анимацию молни
public class ChainLightningEffect : EffectBase
{
    private int _maxChainLinks;
    private float _chainLinksDamage;
    private float _areaRadius;
    private TargetsFinder _targetsFinder; //    Можно добавить метод поиска цели в области, тогда можно будет сделать перекидывание молнии, как задумывалось

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _maxChainLinks = data.MaxChainLinks;
        _chainLinksDamage = data.ChainLinksDamage;
        _areaRadius = data.AreaRadius;

        _targetsFinder = GetComponentInParent<TargetsFinder>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        ApplyDamage(GetNearestTarget(attackEventArgs.DamagedTargets), GetTargetsInArea());
    }

    private DamageableObject GetNearestTarget(List<DamageableObject> targets)
    {
        return targets
            .MinElement(target => Vector2.Distance(
                target.transform.position, 
                transform.position));
    }

    private void ApplyDamage(DamageableObject firstTarget, List<DamageableObject> links)
    {
        if (firstTarget == null || links?.Count == 0 )
            return;

        firstTarget.ApplyDamage(_parameters.Damage);
        PlayVisualEffect(transform, firstTarget.transform);
        links.Remove(firstTarget);

        if (links.Count > _maxChainLinks)
            links = links.GetRange(0, _maxChainLinks - 1);

        var previousTarget = firstTarget;
        foreach (var link in links)
        {
            link.ApplyDamage(_chainLinksDamage);
            PlayVisualEffect(previousTarget.transform, link.transform);
            previousTarget = link;
        }
    }

    private void PlayVisualEffect(Transform start, Transform target)
    {
        var visualEffect = Instantiate(_visualEffect, target);
        var particle = visualEffect.GetComponent<ParticleSystem>();
        var shape = particle.shape.scale / particle.main.startSpeedMultiplier;
        shape.z = (target.position - start.position).sqrMagnitude;
        visualEffect.transform.rotation = Quaternion.LookRotation((target.position - start.position));
        var main = particle.main;
        main.duration = _duration;
        visualEffect.GetComponent<ParticleSystem>().Play();
    }

    private List<DamageableObject> GetTargetsInArea()
    {
        return _targetsFinder.FindTargetsInCircle(_areaRadius);
    }
}
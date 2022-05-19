using System.Collections.Generic;
using Edgar.Legacy.GeneralAlgorithms.Algorithms.Common;
using UnityEngine;

//TODO: добавить анимацию молнии, добавить различаемость других противников, помимо с классом skeletonsamurai
public class ChainLightningEffect : Effect, IEffect 
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

    public void ApplyEffect(AttackEventArgs attackEventArgs)
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
        firstTarget.ApplyDamage(_parameters.Damage);
        links.Remove(firstTarget);

        if (links.Count > _maxChainLinks)
            links = links.GetRange(0, _maxChainLinks - 1);

        foreach (var link in links)
            link.ApplyDamage(_chainLinksDamage);
    }

    private List<DamageableObject> GetTargetsInArea()
    {
        return _targetsFinder.FindTargetsInCircle(_areaRadius);
    }
}
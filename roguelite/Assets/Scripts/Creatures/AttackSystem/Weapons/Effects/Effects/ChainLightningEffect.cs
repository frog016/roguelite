using System.Collections.Generic;
using Edgar.Legacy.GeneralAlgorithms.Algorithms.Common;
using UnityEngine;

public class ChainLightningEffect : EffectBase
{
    private TargetsFinder _targetsFinder; //    Можно добавить метод поиска цели в области, тогда можно будет сделать перекидывание молнии, как задумывалось

    public override void Initialize(EffectData data)
    {
        base.Initialize(data);
        _targetsFinder = GetComponentInParent<TargetsFinder>();
    }

    public override void ApplyEffect(AttackEventArgs attackEventArgs)
    {
        if (!RandomChanceGenerator.IsEventHappened(EffectData.ProcProbability) || attackEventArgs.DamagedTargets.Count <= 0)
            return;

        var data = EffectData as ChainLightningEffectData;
        var firstTarget = GetNearestTarget(attackEventArgs.DamagedTargets);
        var links = _targetsFinder.FindTargetsInCircle(data.AreaRadius);

        if (firstTarget != null)
            LaunchChainLightning(firstTarget, links);
    }

    private void LaunchChainLightning(DamageableObject firstTarget, List<DamageableObject> links)
    {
        var data = EffectData as ChainLightningEffectData;

        firstTarget.ApplyDamage(data.Damage);
        links.Remove(firstTarget);
        PlayVisualEffect(transform, firstTarget.transform);

        var previousTarget = firstTarget;
        foreach (var link in links.GetRange(0, Mathf.Min(links.Count, data.MaxChainLinks)))
        {
            link.ApplyDamage(data.ChainLinksDamage);
            PlayVisualEffect(previousTarget.transform, link.transform);
            previousTarget = link;
        }
    }

    private DamageableObject GetNearestTarget(List<DamageableObject> targets)
    {
        return targets
            .MinElement(target => Vector2.Distance(
                target.transform.position,
                transform.position));
    }
}
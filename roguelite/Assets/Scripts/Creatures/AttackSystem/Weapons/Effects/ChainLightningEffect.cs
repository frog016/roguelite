using System.Collections.Generic;
using UnityEngine;

//TODO: добавить анимацию молнии, добавить различаемость других противников, помимо с классом skeletonsamurai
public class ChainLightningEffect : Effect, IEffect 
{
    private int _maxChainLinks;
    private float _chainLinksDamage;
    private float _areaRadius;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _maxChainLinks = data.MaxChainLinks;
        _chainLinksDamage = data.ChainLinksDamage;
        _areaRadius = data.AreaRadius;
    }

    public void ApplyEffect(List<DamageableObject> targets)
    {
        if (!RandomChanceGenerator.IsEventHappened(_procProbability))
            return;

        ApplyDamage(GetNearestTarget(targets), GetTargetsInArea());
    }

    private DamageableObject GetNearestTarget(List<DamageableObject> targets)
    {
        var nearestTarget = new DamageableObject();
        var shortestDist = float.MaxValue;
        foreach (var target in targets)
        {
            if (shortestDist > Vector3.Distance(target.transform.position, transform.position))
            {
                nearestTarget = target;
                shortestDist = Vector3.Distance(target.transform.position, transform.position);
            }
        }
        return nearestTarget;
    }

    private void ApplyDamage(DamageableObject firstLink, List<DamageableObject> links)
    {
        firstLink.ApplyDamage(_parameters.Damage);
        links.Remove(firstLink);
        if (links.Count > _maxChainLinks)
            links = links.GetRange(0, _maxChainLinks - 1);
        foreach (var link in links)
            link.ApplyDamage(_chainLinksDamage);
    }

    private List<DamageableObject> GetTargetsInArea()
    {
        var targetsList = new List<DamageableObject>();
        var objectsInArea = Physics2D.OverlapCircleAll(transform.position, _areaRadius);
        foreach(var obj in objectsInArea)
            if (obj.TryGetComponent<SkeletonSamurai>(out SkeletonSamurai a)) //включает в себя только противников с классом skeletonsamurai, может не видеть других
                targetsList.Add(obj.GetComponent<DamageableObject>());
        return targetsList;
    }
}

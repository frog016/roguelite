using System;
using System.Linq;

public class RandomReplacementBag : Item
{
    private EffectList _effectList;

    private void Awake()
    {
        _effectList = transform.parent.GetComponentInChildren<EffectList>();
    }

    protected override void UseItem()
    {
        if (_usesCount <= 0)
            return;

        var effectType = typeof(EffectBase);
        var randomEffectTypes = effectType.Assembly.ExportedTypes
            .Where(type => effectType.IsAssignableFrom(type) && !type.IsAbstract)
            .GetRandomItems(4);

        var oldEffects = _effectList.Effects.ToList();
        foreach (var pair in oldEffects.Zip(randomEffectTypes, Tuple.Create))
            _effectList.Replace(pair.Item1.GetType(), pair.Item2);

        _usesCount--;
        Destroy(this);
    }
}
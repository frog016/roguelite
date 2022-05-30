using System;
using System.Linq;

public class RandomReplacementBag : Item
{
    private EffectsList _effectsList;

    private void Awake()
    {
        _effectsList = transform.parent.GetComponentInChildren<EffectsList>();
    }

    protected override void UseItem()
    {
        if (_usesCount <= 0)
            return;

        var effectType = typeof(EffectBase);
        var randomEffectTypes = effectType.Assembly.ExportedTypes
            .Where(type => effectType.IsAssignableFrom(type) && !type.IsAbstract)
            .GetRandomItems(4);

        var oldEffects = _effectsList.Effects.ToList();
        foreach (var pair in oldEffects.Zip(randomEffectTypes, Tuple.Create))
            _effectsList.Replace(pair.Item1.GetType(), pair.Item2);

        _usesCount--;
        Destroy(this);
    }
}

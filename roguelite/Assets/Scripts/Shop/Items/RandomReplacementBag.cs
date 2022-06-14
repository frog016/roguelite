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
        if (_itemData.UsesCount <= 0)
            return;

        var effectType = typeof(EffectBase);
        var randomEffectTypes = effectType.Assembly.ExportedTypes
            .Where(type => effectType.IsAssignableFrom(type) && !type.IsAbstract)
            .GetRandomItems(4);

        foreach (var pair in _effectList.ToList().Zip(randomEffectTypes, Tuple.Create))
            _effectList.Replace(pair.Item1.GetType(), pair.Item2);

        _itemData.UsesCount--;
        Destroy(this);
    }
}

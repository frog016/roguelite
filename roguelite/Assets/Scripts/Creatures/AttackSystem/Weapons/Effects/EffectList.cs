using System;
using System.Linq;

public class EffectList : ComponentList<EffectBase>
{
    public int MaxCapacity { get; set; }

    protected override void Awake()
    {
        base.Awake();
        MaxCapacity = 4;
    }

    public void AddOrUpgrade(Type effectType)
    {
        if (_elements.Count != MaxCapacity)
        {
            AddEffect(effectType);
            return;
        }

        Upgrade(effectType);
    }

    public void Replace(Type oldElement, Type newElement)
    {
        var element = _elements.FirstOrDefault(effect => effect.GetType() == oldElement);
        if (element == null)
            return;

        _elements.Remove(element);
        Destroy(element);
        AddEffect(newElement);
    }

    private void AddEffect(Type effectType)
    {
        var data = EffectDataRepository.Instance.FindDataByAssociatedType(effectType);
        var effect = Add(effectType);
        effect.Initialize(data);
        OnListUpdated.Invoke(effect);
    }

    private void Upgrade(Type effectType)
    {
        var effect = _elements
            .FirstOrDefault(effect => effect.GetType() == effectType);
        if (effect != null)
            return;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine;
using UnityEngine.Events;

public class EffectList : MonoBehaviour
{
    public List<EffectBase> Effects { get; private set; }
    public UnityEvent<EffectData> OnEffectAddedEvent { get; private set; }

    private int _maxCapacity;

    private void Awake()
    {
        _maxCapacity = 4;
        Effects = new List<EffectBase>();
        OnEffectAddedEvent = new UnityEvent<EffectData>();
    }

    public void AddOrUpgrade(Type effectType)
    {
        if (Effects.Count != _maxCapacity)
        {
            AddEffect(effectType);
            return;
        }

        Upgrade(effectType);
    }

    public void Replace(Type oldEffectType, Type newEffectType)
    {
        var effect = Effects.FirstOrDefault(effect => effect.GetType() == oldEffectType);
        if (effect == null)
            return;

        Effects.Remove(effect);
        AddEffect(newEffectType);
    }

    private void AddEffect(Type effectType)
    {
        var data = EffectDataRepository.Instance.FindDataByAssociatedType(effectType);
        var effect = gameObject.AddComponent(effectType) as EffectBase;
        effect.Initialize(data);
        Effects.Add(effect);
        OnEffectAddedEvent.Invoke(data);
    }

    private void Upgrade(Type effectType)
    {
        var effect = Effects
            .FirstOrDefault(effect => effect.GetType() == effectType);
        if (effect != null)
            return;
    }
}
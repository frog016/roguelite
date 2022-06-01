using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine;
using UnityEngine.Events;

public class EffectList : MonoBehaviour    //  TODO: ������� ����� ����� �� ���������� ��������, ���� �� _maxCapacity
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

    public void AddOrUpdate(Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);

        if (Effects.Count != _maxCapacity)
        {
            var newEffect = gameObject.AddComponent(effectType) as EffectBase;
            AddEffect(newEffect, data);
            return;
        }

        var effect = Effects
            .FirstOrDefault(effect => effect.GetType() == effectType);
        if (effect != null)
            AddEffect(effect, data);
    }

    public void Replace(Type oldEffectType, Type newEffectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(newEffectType);

        var effect = Effects.FirstOrDefault(effect => effect.GetType() == oldEffectType);
        if (effect == null)
            return;

        Effects.Remove(effect);
        var newEffect = gameObject.AddComponent(newEffectType) as EffectBase;
        AddEffect(newEffect, data);
    }

    private void AddEffect(EffectBase effect, EffectData data)
    {
        Effects.Add(effect);
        effect.InitializeEffect(data);

        OnEffectAddedEvent.Invoke(data);
    }
}
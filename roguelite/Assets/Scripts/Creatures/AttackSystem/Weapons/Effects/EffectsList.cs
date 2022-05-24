using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine;

public class EffectsList : MonoBehaviour    //  TODO: Сделать выбор среди не полученных эффектов, если не _maxCapacity
{
    public List<EffectBase> Effects { get; private set; }

    private int _maxCapacity;

    private void Awake()
    {
        _maxCapacity = 4;
        Effects = new List<EffectBase>();
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

    private void AddEffect(EffectBase effect, EffectData data)
    {
        Effects.Add(effect);
        effect.InitializeEffect(data);
    }
}
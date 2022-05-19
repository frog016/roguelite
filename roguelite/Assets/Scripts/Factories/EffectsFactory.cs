using System;
using Database.MutableDatabases;
using UnityEngine;

public class EffectsFactory : SingletonObject<EffectsFactory>, IFactory<EffectBase>
{
    public EffectBase CreateObject(GameObject parent, Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);
        var effect = parent.GetComponentInChildren<EffectsList>().AddEffect(effectType, data);

        return effect;
    }
}

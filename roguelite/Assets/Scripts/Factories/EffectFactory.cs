using System;
using Database.MutableDatabases;
using UnityEngine;

public class EffectFactory : SingletonObject<EffectFactory>, IFactory<IEffect>
{
    public IEffect CreateObject(GameObject parent, Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);
        var effect = parent.GetComponentInChildren<EffectsList>().AddEffect(effectType, data);
        Debug.Log($"You got the {effect}.");
        return effect;
    }
}

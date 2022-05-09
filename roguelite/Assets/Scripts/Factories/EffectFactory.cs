using System;
using Database.MutableDatabases;
using UnityEngine;

public class EffectFactory : SingletonObject<EffectFactory>, IFactory<IEffect>
{
    public IEffect CreateObject(GameObject parent, Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);
        return parent.GetComponent<EffectsList>().AddEffect(effectType, data);
    }
}

using System;
using Database.MutableDatabases;
using UnityEngine;

public class EffectFactory : SingletonObject<EffectFactory>, IFactory<IEffect>
{
    public void CreateObject(GameObject parent, Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);
        parent.GetComponent<EffectsList>().AddEffect(effectType, data);
    }
}

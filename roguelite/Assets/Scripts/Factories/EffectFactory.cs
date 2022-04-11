using System;
using Database.MutableDatabases;

public class EffectFactory : SingletonObject<EffectFactory>, IFactory<IEffect>
{
    public IEffect CreateObject(Type effectType)
    {
        var data = EffectsDatabase.Instance.GetDataByType(effectType);
        var effect = (IEffect)Activator.CreateInstance(effectType, data);
        return effect;
    }
}

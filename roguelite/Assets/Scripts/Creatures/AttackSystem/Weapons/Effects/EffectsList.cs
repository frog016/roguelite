using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsList : MonoBehaviour
{
    public List<EffectBase> Effects { get; private set; }

    private void Awake()
    {
        Effects = new List<EffectBase>();
    }

    public EffectBase AddEffect(Type effectType, EffectData data)
    {
        var effect = gameObject.AddComponent(effectType) as EffectBase;
        effect.InitializeEffect(data);

        return effect;
    }
}

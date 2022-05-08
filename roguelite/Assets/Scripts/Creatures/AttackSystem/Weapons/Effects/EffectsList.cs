using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsList : MonoBehaviour
{
    public List<IEffect> Effects { get; private set; }

    private void Awake()
    {
        Effects = new List<IEffect>();
    }

    public void AddEffect(Type effectType, EffectData data)
    {
        var newEffect = gameObject.AddComponent(effectType);
        (newEffect as Effect)?.InitializeEffect(data);
        Effects.Add(newEffect as IEffect);
    }
}

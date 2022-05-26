using System;
using UnityEngine;

[Serializable]
public class EffectDataInfo : EffectData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;

    public Sprite Sprite => _sprite;
    public string Description => _description;
}

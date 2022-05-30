using System;
using UnityEngine;

[Serializable]
public class EffectDataInfo : EffectData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;
    [SerializeField] private GameObject _visualEffect;

    public Sprite Sprite => _sprite;
    public string Description => _description;
    public GameObject VisualEffect => _visualEffect;
}

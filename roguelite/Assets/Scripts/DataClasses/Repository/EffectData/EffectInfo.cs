using System;
using UnityEngine;

[Serializable]
public class EffectInfo : Info
{
    [SerializeField] private GameObject _visualEffect;
    
    public GameObject VisualEffect => _visualEffect;
}

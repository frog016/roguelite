using System;
using UnityEngine;

[Serializable]
public class ItemDataInfo : ItemData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;
    [SerializeField] private float _cost;

    public Sprite Sprite => _sprite;
    public string Description => _description;
    public float Cost => _cost;
}

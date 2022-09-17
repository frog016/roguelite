using System;
using UnityEngine;

[Serializable]
public class Info
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] [TextArea] private string _description;

    public Sprite Sprite => _sprite;
    public string Description => _description;
}

using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

[Serializable]
public class AnimationDirection
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private List<AnimationData> _animations;

    public Vector2 Direction => _direction;
    public List<AnimationData> Animations => _animations;
}

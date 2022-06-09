using System;
using Spine.Unity;
using UnityEngine;

[Serializable]
public class OrientedAnimation
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private SkeletonDataAsset _animation;

    public Vector2 Direction => _direction;
    public SkeletonDataAsset Animation => _animation;
}

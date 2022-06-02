using System;
using Spine.Unity;
using UnityEngine;

[Serializable]
public class AnimationData
{
    [SerializeField] private AnimationState _state;
    [SerializeField] private SkeletonDataAsset _dataAsset;

    public AnimationState State => _state;
    public SkeletonDataAsset DataAsset => _dataAsset;
}

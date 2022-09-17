using System;
using Spine.Unity;
using UnityEngine;

[Serializable]
public class AnimationData
{
    [SerializeField] private string _name;
    [SerializeField] private SkeletonDataAsset _data;

    public string Name => _name;
    public SkeletonDataAsset Data => _data;
}

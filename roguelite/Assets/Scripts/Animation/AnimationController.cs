using System;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;

#if UNITY_EDITOR

using Spine.Unity.Editor;

#endif
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private bool _reversed;
    [SerializeField] private List<AnimationDirection> _animationDirections;

    private Vector2 _curentDirection;
    private AnimationState _currentAnimationState;
    private MoveController _moveController;
    private SkeletonAnimation _skeletonAnimation;

    private void Awake()
    {
        _moveController = GetComponentInParent<MoveController>();
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Start()
    {
        _moveController.OnObjectMovedEvent.AddListener(() => SetAnimation(AnimationState.Walk));
        var weapon = transform.parent.GetComponentInChildren<WeaponBase>();
        weapon.OnAttackEvent.AddListener(_ => SetAnimation(AnimationState.Fight));
        weapon.OnAttackEndedEvent.AddListener(() => SetAnimation(AnimationState.Idle));
    }

    private void SetAnimation(AnimationState state)
    {
        var x = Math.Abs(_moveController.Direction.x) < 1e-10 ? 0 : -1;
        var y = Math.Abs(_moveController.Direction.y) < 1e-10 ? 0 : Math.Sign(_moveController.Direction.y) * 1;
        if (x == -1 && y == 0)
            y = -1;

        
        var animationList = _animationDirections.FirstOrDefault(animationDirection => animationDirection.Direction == new Vector2(x, y));
        var animation = animationList?.Animations.FirstOrDefault(a => a.State == state);
        if (_curentDirection == animationList?.Direction || _currentAnimationState == animation?.State)    //  TODO: Убрать это при рефакторинге (Когда перенесу код управления в IState на вход в состояние)
            return;

        var rotation = new Vector2(180, 0);
        
        if (_reversed)
            (rotation.x, rotation.y) = (rotation.y, rotation.x);

        _skeletonAnimation.skeletonDataAsset = animation?.DataAsset;
        _skeletonAnimation.AnimationName = animation?.State.ToString();
        ReloadAsset(_skeletonAnimation.skeletonDataAsset);
        ReinitializeComponent(_skeletonAnimation);
        transform.rotation = Quaternion.Euler(0, _moveController.Direction.x > 0 ? 180 : 0, 0);
        _currentAnimationState = state;
        _curentDirection = animationList.Direction;
    }

    private void ReloadAsset(SkeletonDataAsset skeletonDataAsset)
    {
        if (skeletonDataAsset != null)
        {
            foreach (AtlasAssetBase aa in skeletonDataAsset.atlasAssets)
            {
                if (aa != null) aa.Clear();
            }
            skeletonDataAsset.Clear();
        }
        skeletonDataAsset.GetSkeletonData(true);
    }

    public static void ReinitializeComponent(SkeletonRenderer component)
    {
        if (component == null) return;
        if (!SkeletonDataAssetIsValid(component.SkeletonDataAsset)) return;

        var stateComponent = component as IAnimationStateComponent;
        Spine.AnimationState oldAnimationState = null;
        if (stateComponent != null)
        {
            oldAnimationState = stateComponent.AnimationState;
        }

        component.Initialize(true); // implicitly clears any subscribers

        if (oldAnimationState != null)
        {
            stateComponent.AnimationState.AssignEventSubscribersFrom(oldAnimationState);
        }

        component.LateUpdate();
    }

    public static bool SkeletonDataAssetIsValid(SkeletonDataAsset asset)
    {
        return asset != null && asset.GetSkeletonData(quiet: true) != null;
    }
}

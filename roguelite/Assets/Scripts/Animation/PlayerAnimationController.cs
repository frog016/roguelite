using System;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private bool _reversed;
    [SerializeField] private List<OrientedAnimation> _orientedAnimations;

    private Vector2 _oldDirection;
    private MoveController _moveController;
    private SkeletonAnimation _skeletonAnimation;
    private SkeletonDataAsset _currentAnimation;

    private void Awake()
    {
        _moveController = GetComponentInParent<MoveController>();
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _currentAnimation = _skeletonAnimation.SkeletonDataAsset;

        _oldDirection = _moveController.Direction;
    }

    private void Start()
    {
        _moveController.OnObjectMovedEvent.AddListener(DefineAnimationDirection);
        GetComponentInParent<StateChanger>().StateHandler.OnStateChangedEvent.AddListener(PlayAnimation);
    }

    private void DefineAnimationDirection()
    {
        var x = Math.Abs(_moveController.Direction.x) < 1e-10 ? 0 : -1;
        var y = Math.Abs(_moveController.Direction.y) < 1e-10 ? 0 : Math.Sign(_moveController.Direction.y);

        var direction = new Vector2(x, y);
        var currentAnimation = _orientedAnimations
            .FirstOrDefault(animationDirection => animationDirection.Direction == direction)?.Animation;

        _currentAnimation = currentAnimation;
        _skeletonAnimation.skeletonDataAsset = _currentAnimation;

        if (_oldDirection != direction)
            _skeletonAnimation.ReloadAsset();

        TryRotate();
        _oldDirection = direction;
    }

    private void PlayAnimation(IState state)
    {
        var type = state.GetType();
        _skeletonAnimation.skeletonDataAsset = _currentAnimation;
        _skeletonAnimation.AnimationName = GetName(type);
        _skeletonAnimation.ReloadAsset();
    }

    private void TryRotate()
    {
        var pair = _reversed ? (0, 180) : (180, 0);
        var rotation = new Vector2(pair.Item1, pair.Item2);
        transform.rotation = Quaternion.Euler(0, _moveController.Direction.x > 0 ? rotation.x : rotation.y, 0);
    }

    private string GetName(Type state)
    {
        var stateName = state.Name;
        var index = stateName.IndexOf("State");
        var animationName = stateName.Remove(index);
        if (animationName == "Attack")
            animationName += "Left";

        return animationName;
    }
}

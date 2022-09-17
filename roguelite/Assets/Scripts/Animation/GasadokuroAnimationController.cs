using System;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class GasadokuroAnimationController : MonoBehaviour
{
    [SerializeField] private bool _reversed;
    [SerializeField] private List<OrientedAnimation> _orientedAnimations;

    private string _name;
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
        transform.parent.GetComponentInChildren<WeaponBase>().OnAttackEvent.AddListener(SetAttackName);
    }

    private void DefineAnimationDirection()
    {
        var x = Math.Abs(_moveController.Direction.x) < 1e-10 ? 0 : -1;
        var y = Math.Abs(_moveController.Direction.y) < 1e-10 ? 0 : Math.Sign(_moveController.Direction.y);
        if (x == -1 && y == 0)
            y = -1;

        var direction = new Vector2(x, y);
        var currentAnimation = _orientedAnimations
            .FirstOrDefault(animationDirection => animationDirection.Direction == direction)?.Animation;

        _currentAnimation = currentAnimation;
        _skeletonAnimation.skeletonDataAsset = _currentAnimation;

        if (_oldDirection != direction)
            _skeletonAnimation.ReloadAsset();

        _oldDirection = direction;
        TryRotate();
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
        var pair = _oldDirection == new Vector2(-1, 1) ? (0, 180) : (180, 0);
        var rotation = new Vector2(pair.Item1, pair.Item2);
        transform.rotation = Quaternion.Euler(0, _moveController.Direction.x > 0 ? rotation.x : rotation.y, 0);
    }

    private string GetName(Type state)
    {
        var stateName = state.Name;
        var index = stateName.IndexOf("State");
        var animationName = stateName.Remove(index);
        if (animationName == "Attack" && _name != "")
            animationName = _name;

        return animationName;
    }

    private void SetAttackName(AttackBase attack)
    {
        if (attack is FootKick)
            _name = "Kick";
        else if (attack is ThrowStone)
            _name = "Throw stone";
        else if (attack is GrabAndThrow)
            _name = "Successful capture";

        _skeletonAnimation.skeletonDataAsset = _currentAnimation;
        _skeletonAnimation.AnimationName = _name;
        _skeletonAnimation.ReloadAsset();
    }
}
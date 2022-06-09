using System;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private bool _reversed;
    [SerializeField] private List<OrientedAnimationExt> _orientedAnimations;

    private Vector2 _oldDirection;
    private MoveController _moveController;
    private SkeletonAnimation _skeletonAnimation;
    private List<AnimationData> _currentAnimation;

    private void Awake()
    {
        _moveController = GetComponentInParent<MoveController>();
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _currentAnimation = new List<AnimationData>();

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
        if (x == -1 && y == 0)
            y = -1;

        var direction = new Vector2(x, y);
        var currentAnimation = _orientedAnimations
            .FirstOrDefault(animationDirection => animationDirection.Direction == direction)?.Datas;

        _currentAnimation = currentAnimation;

        //if (_oldDirection != direction)
        //    _skeletonAnimation.ReloadAsset();

        TryRotate();
        _oldDirection = direction;
    }

    private void PlayAnimation(IState state)
    {
        var type = state.GetType();
        var newName = GetName(type);
        _skeletonAnimation.skeletonDataAsset = _currentAnimation.FirstOrDefault(data => data.Name == newName)?.Data;
        _skeletonAnimation.AnimationName = newName;
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
            animationName = "Fight";

        return animationName;
    }
}

[Serializable]
public class OrientedAnimationExt
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private List<AnimationData> _datas;

    public Vector2 Direction => _direction;
    public List<AnimationData> Datas => _datas;
}

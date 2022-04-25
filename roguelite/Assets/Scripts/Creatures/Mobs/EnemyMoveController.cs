using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class EnemyMoveController : MoveController
{
    private float _radius;
    private DamageableObject _target;
    private CircleCollider2D _circleCollider;
    private StateHandler _stateHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _radius = GetComponentInChildren<Weapon>().Data.FirstAttackData.AttackRadius;
        _stateHandler = GetComponent<StateHandler>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!_circleCollider.IsTouching(otherCollider) || otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        _target = otherCollider.GetComponent<DamageableObject>();
        _target.OnObjectDeath.AddListener(() => _stateHandler.SetState(new StandState()));
        _stateHandler.SetState(new FollowState(this, _target.gameObject));
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (_target == null || otherCollider.gameObject != _target.gameObject)
            return;

        if (Mathf.Abs(Vector2.Distance(_target.transform.position, transform.position)) < _radius)
        {
            _stateHandler.SetState(new AttackState(this, _target.gameObject));
            return;
        }

        _stateHandler.SetState(new FollowState(this, _target.gameObject));

    }
}

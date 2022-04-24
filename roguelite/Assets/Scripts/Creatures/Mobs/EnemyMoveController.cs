using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class EnemyMoveController : MoveController
{
    public UnityEvent OnTargetReached { get; private set; }

    private float _radius;
    private DamageableObject _target;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        OnTargetReached = new UnityEvent();
    }

    private void Start()
    {
        _radius = GetComponentInChildren<Weapon>().Data.FirstAttackData.AttackRadius;
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove() //TODO: Сделать нормальное приследование цели
    {
        if (_target == null || Mathf.Abs(Vector2.Distance(_target.transform.position, transform.position)) < _radius)
        {
            if (_target != null)
                OnTargetReached.Invoke();
            return;
        }

        var direction = (_target.transform.position - transform.position);
        Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!_circleCollider.IsTouching(otherCollider) || otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        _target = otherCollider.GetComponent<DamageableObject>();
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class EnemyMoveController : MoveController
{
    [SerializeField] private float _radius;

    private DamageableObject _target;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove() //TODO: Сделать нормальное приследование цели
    {
        if (_target is null || Mathf.Abs(Vector2.Distance(_target.transform.position, transform.position)) < _radius)
            return;

        var direction = (_target.transform.position - transform.position).normalized;
        Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!_circleCollider.IsTouching(otherCollider) || otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        _target = otherCollider.GetComponent<DamageableObject>();
    }
}

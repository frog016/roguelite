using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _damage;
    private Vector2 _finalPosition;
    private DamageableObject _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(DamageableObject target, float damage)
    {
        Initialize(target, damage);

        var position = target.transform.position;
        _finalPosition = position;
        _rigidbody.velocity = _speed * (position - transform.position).normalized;
    }

    private void Initialize(DamageableObject target, float damage)
    {
        _target = target;
        _target.OnObjectDeath.AddListener(DestroyProjectile);
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (CheckDistance())
        {
            DestroyProjectile();
            return;
        }

        var damageableObject = otherCollider.GetComponent<Creature>();
        if (_target == null || damageableObject == null || !damageableObject.Equals(_target))
            return;

        _target.ApplyDamage(_damage);
    }

    private bool CheckDistance()
    {
        return Vector2.Distance(transform.position, _finalPosition) < 1e-6;
    }

    private void DestroyProjectile()
    {
        _target.OnObjectDeath.RemoveListener(DestroyProjectile);
        Destroy(gameObject);
    }
}

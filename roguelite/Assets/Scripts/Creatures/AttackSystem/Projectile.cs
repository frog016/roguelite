using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _damage;
    private DamageableObject _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(DamageableObject target, float damage)
    {
        Initialize(target, damage);
        _rigidbody.velocity = _speed * (target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(target.transform.position, transform.position) - 90);
    }

    private void Initialize(DamageableObject target, float damage)
    {
        _target = target;
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var damageableObject = otherCollider.GetComponent<DamageableObject>();
        if (_target != null && damageableObject != null)
        {
            if (!damageableObject.Equals(_target))
                return;

            _target.ApplyDamage(_damage);
            DestroyProjectile();
        }

        if (!otherCollider.isTrigger && damageableObject == null && otherCollider.name != "Foot")
            DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

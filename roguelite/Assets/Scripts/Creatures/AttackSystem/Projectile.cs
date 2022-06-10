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
        transform.rotation = Quaternion.LookRotation((target.transform.position - transform.position));
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

        if (!otherCollider.isTrigger && damageableObject == null && otherCollider.GetComponentInParent<DamageableObject>() == null)
            DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

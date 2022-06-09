using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour //  TODO: Рефакторинг
{
    [SerializeField] protected float _speed;
    [SerializeField] private float _dashCooldown;

    public Vector2 Direction { get; protected set; }
    public UnityEvent OnObjectMovedEvent { get; private set; }
    public UnityEvent OnDashEndedEvent { get; private set; }

    protected Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        Direction = Vector2.right;
        OnObjectMovedEvent = new UnityEvent();
        OnDashEndedEvent = new UnityEvent();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Move(Vector3 direction)
    {
        Direction = direction.normalized;
        _rigidbody.MovePosition(transform.position + direction.normalized * _speed * Time.fixedDeltaTime);
        OnObjectMovedEvent.Invoke();
    }

    public void Dash(Vector2 direction = default)
    {
        StartCoroutine(DashCoroutine(direction));
    }

    private IEnumerator DashCoroutine(Vector2 direction)
    {
        var newDirection = direction == default ? Direction : direction;
        var dashForce = 10f;
        _rigidbody.velocity = newDirection * dashForce;
        yield return new WaitForSeconds(0.1f);
        OnObjectMovedEvent.Invoke();
        _rigidbody.velocity = Vector2.zero;
        OnDashEndedEvent.Invoke();
        yield return new WaitForSeconds(_dashCooldown);
    }
}

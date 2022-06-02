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

    protected Rigidbody2D _rigidbody;
    protected bool _isDashed;
    protected bool _canMove;

    protected virtual void Awake()
    {
        Direction = Vector2.right;
        _canMove = true;
        OnObjectMovedEvent = new UnityEvent();
    }

    public virtual void Move(Vector3 direction)
    {
        if (!_canMove)
            return;

        Direction = direction.normalized;
        _rigidbody.MovePosition(transform.position + direction.normalized * _speed * Time.fixedDeltaTime);
        OnObjectMovedEvent.Invoke();
    }

    public void ContinueMoving()
    {
        _canMove = true;
    }

    public void StopMoving()
    {
        _canMove = false;
    }

    public void Dash(Vector2 direction = default)
    {
        if (_isDashed)
            return;
        StartCoroutine(DashCoroutine(direction));
    }

    private IEnumerator DashCoroutine(Vector2 direction)
    {
        _isDashed = true;
        _canMove = false;
        var newDirection = direction == default ? Direction : direction;
        var dashForce = 10f;
        _rigidbody.velocity = newDirection * dashForce;
        yield return new WaitForSeconds(0.1f);
        _canMove = true;
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(_dashCooldown);
        _isDashed = false;
    }
}

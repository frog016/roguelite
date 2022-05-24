using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private float _dashCooldown;

    public Vector2 Direction { get; protected set; }
    protected Rigidbody2D _rigidbody;

    protected bool _isDashed;
    protected bool _canMove;

    protected virtual void Awake()
    {
        Direction = Vector2.right;
        _canMove = true;
    }

    public virtual void Move(Vector3 direction)
    {
        if (!_canMove)
            return;

        var normalizedDirection = direction.normalized;
        Direction = Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y)
            ? new Vector2(normalizedDirection.x, 0) : new Vector2(0, normalizedDirection.y);
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
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
        StartCoroutine(DashCoroutine(direction));
    }

    private IEnumerator DashCoroutine(Vector2 direction)
    {
        _isDashed = true;
        var newDirection = direction == default ? Direction : direction;
        var dashForce = 10f;
        _rigidbody.velocity = newDirection * dashForce;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(_dashCooldown);
        _isDashed = false;
    }
}

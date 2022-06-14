using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour //  TODO: Рефакторинг
{
    public bool IsDashed { get; private set; }
    public Vector2 Direction { get; protected set; }
    public UnityEvent OnObjectMovedEvent { get; private set; }
    public UnityEvent OnDashEndedEvent { get; private set; }
    public MovementData MovementData { get; set; }

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
        _rigidbody.MovePosition(transform.position + direction.normalized * MovementData.MoveSpeed * Time.fixedDeltaTime);
        OnObjectMovedEvent.Invoke();
    }

    public void Dash(Vector2 direction = default)
    {
        if (IsDashed)
            return;

        StartCoroutine(DashCoroutine(direction));
    }

    private IEnumerator DashCoroutine(Vector2 direction)
    {
        IsDashed = true;
        var newDirection = direction == default ? Direction : direction;
        _rigidbody.velocity = newDirection * MovementData.DashSpeed;
        yield return new WaitForSeconds(MovementData.DashActiveTime);
        OnObjectMovedEvent.Invoke();
        _rigidbody.velocity = Vector2.zero;
        OnDashEndedEvent.Invoke();
        yield return new WaitForSeconds(MovementData.DashCooldown);
        IsDashed = false;
    }
}

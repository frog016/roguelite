using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] float _speed;

    public Vector2 Direction { get; private set; }
    protected Rigidbody2D _rigidbody;

    private void Start()
    {
        Direction = Vector2.right;
    }

    protected void Move(Vector3 direction)
    {
        var normalizedDirection = direction.normalized;
        Direction = Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y)
            ? new Vector2(normalizedDirection.x, 0) : new Vector2(0, normalizedDirection.y);
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}

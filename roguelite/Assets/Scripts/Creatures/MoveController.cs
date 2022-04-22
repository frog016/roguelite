using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] float _speed;

    public Vector2 Direction { get; private set; }
    protected Rigidbody2D _rigidbody;

    protected void Move(Vector3 direction)
    {
        Direction = Mathf.Abs(direction.x) >= Mathf.Abs(direction.y)
            ? new Vector2(direction.x, 0) : new Vector2(0, direction.y);
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}

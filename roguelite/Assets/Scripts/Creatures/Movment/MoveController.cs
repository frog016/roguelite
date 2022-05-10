using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] protected float _speed;

    public Vector2 Direction { get; private set; }
    protected Rigidbody2D _rigidbody;

    private void Start()
    {
        Direction = Vector2.right;
    }

    public void Move(Vector3 direction) //  ���� Dash, �� ������ ������
    {
        var normalizedDirection = direction.normalized;
        Direction = Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y)
            ? new Vector2(normalizedDirection.x, 0) : new Vector2(0, normalizedDirection.y);
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }

    public void Dash()
    {
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        var dashForce = 10f;
        _rigidbody.velocity = Direction * dashForce;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.velocity = Vector2.zero;
    }
}

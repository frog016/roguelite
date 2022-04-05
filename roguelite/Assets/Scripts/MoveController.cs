using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal + moveVertical < 1e-10)
            return;

        var direction = new Vector2(moveHorizontal, moveVertical);
        _rigidbody.AddForce(direction * _speed * Time.fixedDeltaTime);
    }
}

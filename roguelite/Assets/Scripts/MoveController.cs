using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed;

    public UnityEvent OnPlayerMove { get; private set; }

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        OnPlayerMove = new UnityEvent();
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(moveHorizontal) < 1e-12 && Mathf.Abs(moveVertical) < 1e-12)
            return;

        var direction = new Vector3(moveHorizontal, moveVertical);
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
        OnPlayerMove.Invoke();
    }
}

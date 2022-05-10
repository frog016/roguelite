using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveController : MoveController
{
    public UnityEvent OnPlayerMove { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        OnPlayerMove = new UnityEvent();
    }

    private void FixedUpdate() //   TODO: Рефакторинг через IState
    {
        if (TryDash())
        {
        }
        else if (TryMove())
        {
        }
    }

    private bool TryMove()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(moveHorizontal) < 1e-12 && Mathf.Abs(moveVertical) < 1e-12)
            return false;

        var direction = new Vector3(moveHorizontal, moveVertical);
        Move(direction);
        OnPlayerMove.Invoke();

        return true;
    }

    private bool TryDash()
    {
        if (Mathf.Abs(Input.GetAxis("Jump")) < 1e-12)
            return false;

        Dash();
        OnPlayerMove.Invoke();

        return true;
    }
}

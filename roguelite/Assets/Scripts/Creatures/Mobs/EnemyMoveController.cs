using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D), typeof(NavMeshAgent))]
public class EnemyMoveController : MoveController
{
    public NavMeshAgent Agent { get; protected set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InitializeAgent();
    }

    public override void Move(Vector3 direction)
    {
        if (!_canMove)
            return;

        var normalizedDirection = (direction - transform.position).normalized;
        Direction = Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y)
            ? new Vector2(normalizedDirection.x, 0) : new Vector2(0, normalizedDirection.y);

        Agent.SetDestination(direction);
    }

    private void InitializeAgent()
    {
        var agent = GetComponent<NavMeshAgent>();
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        var weapon = GetComponentInChildren<WeaponBase>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = _speed;
        agent.stoppingDistance = weapon.MinimalAttackDistance;
        agent.baseOffset = capsuleCollider.size.y / 2;
        agent.radius = capsuleCollider.size.x / 2;
        agent.height = capsuleCollider.size.y;
    }
}

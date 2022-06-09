using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMoveController : MoveController
{
    public NavMeshAgent Agent { get; protected set; }

    protected override void Awake()
    {
        base.Awake();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InitializeAgent();
    }

    public override void Move(Vector3 direction)
    {
        var normalizedDirection = (direction - transform.position).normalized;
        Direction = new Vector2(
            Mathf.Abs(normalizedDirection.x) < 0.2 ? 0 : normalizedDirection.x,
            Mathf.Abs(normalizedDirection.y) < 0.2 ? 0 : normalizedDirection.y);

        Agent.SetDestination(direction);
        OnObjectMovedEvent.Invoke();
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

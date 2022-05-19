using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D), typeof(NavMeshAgent))]
public class EnemyMoveController : MoveController
{
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InitializeAgent();
    }

    private void InitializeAgent()
    {
        var agent = GetComponent<NavMeshAgent>();
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        var weapon = GetComponentInChildren<Weapon>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = _speed;
        agent.stoppingDistance = weapon.MinimalAttackDistance;
        agent.baseOffset = capsuleCollider.size.y / 2;
        agent.radius = capsuleCollider.size.x / 2;
        agent.height = capsuleCollider.size.y;
    }
}

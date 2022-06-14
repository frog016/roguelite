using System.Collections;
using System.Linq;
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
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
        Agent.speed = Speed;
        Agent.stoppingDistance = 1f;
        Agent.baseOffset = capsuleCollider.size.y / 2;
        Agent.radius = capsuleCollider.size.x / 2;
        Agent.height = capsuleCollider.size.y;
        StartCoroutine(SetStoppingDistance());
    }

    private IEnumerator SetStoppingDistance()
    {
        var weapon = GetComponentInChildren<WeaponBase>();
        yield return new WaitUntil(() => weapon.AttackTypes != null && weapon.AttackTypes.Count > 0);
        Agent.stoppingDistance = weapon.GetAttackData(weapon.AttackTypes.First()).AttackRadius;
    }
}

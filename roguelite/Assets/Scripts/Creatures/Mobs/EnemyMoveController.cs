using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D), typeof(NavMeshAgent))]
public class EnemyMoveController : MoveController
{
    private float _radius;
    private DamageableObject _target;
    private StateHandler _stateHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateHandler = GetComponent<StateHandler>();
    }

    private void Start()
    {
        _radius = GetComponentInChildren<Weapon>().Data.FirstAttackData.AttackRadius;
        InitializeAgent();
    }

    private void Update()
    {
        if (_target == null)
            return;

        ChangeState();
    }

    public void SetTarget(DamageableObject target)
    {
        _target = target;
        _target.OnObjectDeath.AddListener(() => _stateHandler.SetState(new StandState()));
        _stateHandler.SetState(new FollowState(this, _target.gameObject));
    }

    private void InitializeAgent()
    {
        var agent = GetComponent<NavMeshAgent>();
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = _speed;
        agent.stoppingDistance = _radius;
        agent.baseOffset = capsuleCollider.size.y / 2;
        agent.radius = capsuleCollider.size.x / 2;
        agent.height = capsuleCollider.size.y;
    }

    private void ChangeState()
    {
        if (Mathf.Abs(Vector2.Distance(_target.transform.position, transform.position)) < _radius)
        {
            _stateHandler.SetState(new AttackState(this, _target.gameObject));
            return;
        }

        _stateHandler.SetState(new FollowState(this, _target.gameObject));
    }
}

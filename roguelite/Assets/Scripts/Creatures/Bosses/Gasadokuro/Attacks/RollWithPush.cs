using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class RollWithPush : AttackBase
{
    [SerializeField] private int _bouncesCount;
   
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private StateChanger _stateChanger;
    private CollisionHandler _collisionHandler;
    private List<DamageableObject> _targets;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponentInParent<Rigidbody2D>();
        _stateChanger = GetComponentInParent<StateChanger>();
        _collisionHandler = GetComponentInParent<CollisionHandler>();
    }

    protected override IEnumerator AttackCoroutine()    //  TODO: Не работает корректно
    {
        yield return  base.AttackCoroutine();

        _targets = new List<DamageableObject>();
        _stateChanger.enabled = false;
        _stateChanger.StateHandler.enabled = false;
        _rigidbody.GetComponent<NavMeshAgent>().enabled = false;
        
        _collisionHandler.AttachedCollider.isTrigger = true;
        _direction = Random.insideUnitCircle;
        _collisionHandler.OnTriggerEnter2DEvent.AddListener(CheckWall);
        _collisionHandler.OnTriggerEnter2DEvent.AddListener(TryApplyDamage);
        RollInDirection();
        _cooldown.TryRestartCooldown();
    }

    private void TryApplyDamage(Collider2D collider)
    {
        var damageableObject = collider.GetComponent<DamageableObject>();
        if (damageableObject == null)
            return;

        damageableObject.ApplyDamage(AttackData.Damage);
        _targets.Add(damageableObject);
    }

    private void CheckWall(Collider2D collider)
    {
        if (collider.GetComponent<CompositeCollider2D>() == null)
            return;

        var collisions = new List<ContactPoint2D>();
        if (_rigidbody.GetContacts(collisions) > 0)
            _direction = Vector2.Reflect(_rigidbody.velocity, collisions[0].normal);
        else
            _direction = Random.insideUnitCircle;
        _bouncesCount--;
        RollInDirection();
    }

    private void RollInDirection()
    {
        if (_bouncesCount > 0)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(_direction * 8, ForceMode2D.Force); //  TODO: MAGIC NUMBER!!!
            Debug.Log(_bouncesCount);
        }
        else
        {
            _collisionHandler.OnTriggerEnter2DEvent.RemoveListener(CheckWall);
            _collisionHandler.OnTriggerEnter2DEvent.RemoveListener(TryApplyDamage);
            _stateChanger.enabled = true;
            _stateChanger.StateHandler.enabled = true;
            _rigidbody.GetComponent<NavMeshAgent>().enabled = true;
            _collisionHandler.AttachedCollider.isTrigger = false;

            OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, _targets.ToList()));
        }
    }
}

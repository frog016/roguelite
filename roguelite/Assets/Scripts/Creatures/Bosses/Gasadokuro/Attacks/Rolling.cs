using System.Collections.Generic;
using UnityEngine;

public class Rolling : AttackBase
{
    [SerializeField] private int _bouncesCount;
    
    private Rigidbody2D _rigidbody;
    private MoveController _moveController;
    private TriggerHandler _triggerHandler;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponentInParent<Rigidbody2D>();
        _moveController = _rigidbody.GetComponent<MoveController>();
        _triggerHandler = _rigidbody.GetComponent<TriggerHandler>();
    }

    public override List<DamageableObject> Attack()
    {
        _bouncesCount = 2;
        _moveController.gameObject.SetActive(false);

        _triggerHandler.AttachedCollider.isTrigger = true;
        _cooldown.TryRestartCooldown();
        RollInDirection();
        _triggerHandler.OnTriggerEnter.AddListener(CheckWall);
        _triggerHandler.OnTriggerEnter.AddListener(TryApplyDamage);

        return new List<DamageableObject>();
    }

    private void TryApplyDamage(Collider2D otherCollider)
    {
        var damageableObject = otherCollider.GetComponent<DamageableObject>();
        if (damageableObject == null)
            return;

        damageableObject.ApplyDamage(AttackData.Damage);
    }

    private void CheckWall(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<CompositeCollider2D>() == null)
            return;

        _bouncesCount--;
        RollInDirection();
    }

    private void RollInDirection()
    {
        if (_bouncesCount > 0)
        {
            var direction = GetRandomDirection();
            _rigidbody.velocity = direction * AttackData.AttackSpeed;
        }
        else
        {
            _triggerHandler.OnTriggerEnter.RemoveListener(CheckWall);
            _triggerHandler.OnTriggerEnter.RemoveListener(TryApplyDamage);
            _moveController.gameObject.SetActive(true);
            _triggerHandler.AttachedCollider.isTrigger = false;
        }
    }

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle;
    }
}
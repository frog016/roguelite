using System.Collections.Generic;
using UnityEngine;

public class Rolling : Attack, IAttack
{
    private int _bouncesCount;
    private TriggerHandler _triggerHandler;
    private Rigidbody2D _rigidbody;
    private MoveController _moveController;
    private Collider2D _hitBox;

    public Rolling(AttackData attackData, TargetsFinder targetsFinder) : base(attackData, targetsFinder)
    {
        _triggerHandler = targetsFinder.GetComponentInParent<TriggerHandler>();
        _rigidbody = targetsFinder.GetComponentInParent<Rigidbody2D>();
        _moveController = targetsFinder.GetComponentInParent<MoveController>();
        _hitBox = targetsFinder.GetComponentInParent<Collider2D>();
    }

    public List<DamageableObject> Attack()
    {
        _bouncesCount = 2;
        _moveController.gameObject.SetActive(false);

        _hitBox.isTrigger = true;
        _cooldown.TryRestartCooldown();
        RollInDirection();
        _triggerHandler.OnTriggerEnter.AddListener(CheckWall);
        _triggerHandler.OnTriggerEnter.AddListener(TryApplyDamage);

        return new List<DamageableObject>();
    }

    public bool IsReady()
    {
        return _cooldown.IsReady;
    }

    private void TryApplyDamage(Collider2D otherCollider)
    {
        var damageableObject = otherCollider.GetComponent<DamageableObject>();
        if (damageableObject == null)
            return;

        damageableObject.ApplyDamage(Data.Damage);
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
            _rigidbody.velocity = direction * Data.AttackSpeed;
        }
        else
        {
            _triggerHandler.OnTriggerEnter.RemoveListener(CheckWall);
            _triggerHandler.OnTriggerEnter.RemoveListener(TryApplyDamage);
            _moveController.gameObject.SetActive(true);
            _hitBox.isTrigger = false;
        }
    }

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle;
    }
}
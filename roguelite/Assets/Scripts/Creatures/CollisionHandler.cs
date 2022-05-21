using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollisionHandler : MonoBehaviour
{
    public Collider2D AttachedCollider { get; private set; }
    public UnityEvent<Collision2D> OnCollisionEnter2DEvent { get; private set; }
    public UnityEvent<Collider2D> OnTriggerEnter2DEvent { get; private set; }

    private HashSet<Collider2D> _myColliders;

    private void Awake()
    {
        AttachedCollider = GetComponent<Collider2D>();

        OnCollisionEnter2DEvent = new UnityEvent<Collision2D>();
        OnTriggerEnter2DEvent = new UnityEvent<Collider2D>();

        _myColliders = new HashSet<Collider2D>(GetComponentsInChildren<Collider2D>());
    }

    private bool IsOtherCollider(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsOtherCollider(collision.collider))
            OnCollisionEnter2DEvent.Invoke(collision);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsOtherCollider(collider))
            OnTriggerEnter2DEvent.Invoke(collider);
    }
}

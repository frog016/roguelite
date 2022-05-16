using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerHandler : MonoBehaviour
{
    public UnityEvent<Collider2D> OnTriggerEnter { get; private set; }
    public UnityEvent<Collider2D> OnTriggerStay { get; private set; }
    public UnityEvent<Collider2D> OnTriggerExit { get; private set; }

    private HashSet<Collider2D> _myColliders;

    private void Awake()
    {
        OnTriggerEnter = new UnityEvent<Collider2D>();
        OnTriggerStay = new UnityEvent<Collider2D>();
        OnTriggerExit = new UnityEvent<Collider2D>();

        _myColliders = new HashSet<Collider2D>(GetComponentsInChildren<Collider2D>());
    }

    private bool IsOtherCollider(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (IsOtherCollider(otherCollider))
            OnTriggerEnter.Invoke(otherCollider);
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (IsOtherCollider(otherCollider))
            OnTriggerStay.Invoke(otherCollider);
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (IsOtherCollider(otherCollider))
            OnTriggerExit.Invoke(otherCollider);
    }
}

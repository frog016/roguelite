using UnityEngine;
using UnityEngine.Events;

public class DamageableObject : MonoBehaviour
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public UnityEvent OnHealthChanged { get; private set; }
    public UnityEvent OnObjectDeath { get; private set; }

    protected virtual void Awake()
    {
        OnHealthChanged = new UnityEvent();
        OnObjectDeath = new UnityEvent();
    }

    public void ApplyDamage(float damage)
    {
        Health -= damage;
        OnHealthChanged?.Invoke();
        if (Health > 0)
            return;

        OnObjectDeath?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnObjectDeath?.RemoveAllListeners();
        OnHealthChanged?.RemoveAllListeners();
    }
}

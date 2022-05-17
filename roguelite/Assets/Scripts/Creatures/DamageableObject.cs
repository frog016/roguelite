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
        Debug.Log($"{gameObject?.name} took {damage} damage. Remaining health is {Health}");
        OnHealthChanged?.Invoke();
        if (Health > 0)
            return;

        OnObjectDeath?.Invoke();
        Destroy(gameObject);
    }

    public void ApplyHeath(float healValue)
    {
        Health = Mathf.Min(Health + healValue, MaxHealth);
    }

    private void OnDestroy()
    {
        OnObjectDeath?.RemoveAllListeners();
        OnHealthChanged?.RemoveAllListeners();
    }
}

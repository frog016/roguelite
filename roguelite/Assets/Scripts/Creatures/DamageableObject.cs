using UnityEngine;
using UnityEngine.Events;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private float _health;

    public UnityEvent OnHealthChanged { get; private set; }
    public UnityEvent OnObjectDeath { get; private set; }

    public float Health => _health;

    private void Awake()
    {
        OnHealthChanged = new UnityEvent();
        OnObjectDeath = new UnityEvent();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke();
        if (_health > 0)
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
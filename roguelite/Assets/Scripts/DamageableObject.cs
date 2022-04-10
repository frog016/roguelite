using UnityEngine;
using UnityEngine.Events;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private float _health;

    public UnityEvent OnHealthChanged;

    private void Awake()
    {
        OnHealthChanged = new UnityEvent();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke();
        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnHealthChanged?.RemoveAllListeners();
    }
}
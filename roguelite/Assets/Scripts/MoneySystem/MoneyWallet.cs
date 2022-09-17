using UnityEngine;
using UnityEngine.Events;

public abstract class MoneyWallet : ScriptableData
{
    [SerializeField] protected float _balance;

    public UnityEvent OnBalanceUpdatedEvent { get; private set; }
    public float Balance => _balance;

    private void Awake()
    {
        OnBalanceUpdatedEvent = new UnityEvent();
    }

    public void AddMoney(float value)
    {
        _balance += value;
        OnBalanceUpdatedEvent.Invoke();
    }

    public bool TrySpendMoney(float value)
    {
        if (!IsEnough(value))
            return false;

        _balance -= value;
        OnBalanceUpdatedEvent.Invoke();
        return true;
    }

    public bool IsEnough(float value) => _balance >= value;
}

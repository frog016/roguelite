using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : SingletonObject<GlobalEventManager>
{
    public UnityEvent OnEnemyDeathEvent { get; private set; }
    public UnityEvent OnRoomClearedEvent { get; private set; }
    public UnityEvent OnPlayerDeathEvent { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        OnEnemyDeathEvent = new UnityEvent();
        OnRoomClearedEvent = new UnityEvent();
        OnPlayerDeathEvent = new UnityEvent();

        OnEnemyDeathEvent.AddListener(CheckRoomCleared);
    }

    private void CheckRoomCleared()
    {
        if (Spawner.Instance.SpawnedUnitsCount > 1)
            return;

        OnRoomClearedEvent.Invoke();
    }

    private void OnDestroy()
    {
        OnEnemyDeathEvent.RemoveAllListeners();
        OnPlayerDeathEvent.RemoveAllListeners();
        OnRoomClearedEvent.RemoveAllListeners();
    }
}

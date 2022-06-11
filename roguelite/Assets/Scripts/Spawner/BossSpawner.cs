using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BossSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private GameObject _hpCardPrefab;

    private RoomDetector _detector;
    private DamageableObject _target;

    private void Start()
    {
        _detector = GetComponentInChildren<RoomDetector>();
        _detector.OnPlayerRoomEnterEvent.AddListener(StartSpawning);
    }

    private void StartSpawning(DamageableObject target)
    {
        _target = target;
        SpawnUnits();
    }

    public void SpawnUnits(SpawnData data = null)   //  Рефакторинг
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();
        var boss = CreatureFactory.Instance.CreateObject(creatureObject, typeof(Gasadokuro));
        boss.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);
        boss.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnBossDeathEvent.Invoke);
        boss.GetComponent<EnemyStateChanger>().SetTarget(_target);

        var hpCard = Instantiate(_hpCardPrefab, FindObjectOfType<PauseManager>().transform);
        var imgae = hpCard.GetComponentsInChildren<Image>().Last();
        boss.OnHealthChanged.AddListener(() => imgae.fillAmount = boss.Health / boss.MaxHealth);
        boss.OnObjectDeath.AddListener(() => Destroy(hpCard));

        _detector.OnPlayerRoomEnterEvent.RemoveListener(StartSpawning);

        Destroy(creatureObject);
    }

    private Vector2 FindPosition()
    {
        var grid = GetComponentInChildren<Grid>();
        return grid.LocalToWorld(GetComponentInChildren<Tilemap>().localBounds.center);
    }
}
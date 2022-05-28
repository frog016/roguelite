using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class BossSpawner : MonoBehaviour, ISpawner
{
    private RoomDetector _detector;
    private DamageableObject _target;

    private void Start()
    {
        _detector = GetComponentInChildren<RoomDetector>();
        _detector.OnPlayerRoomEnterEvent.AddListener(player =>
        {
            _target = player;
            SpawnUnits();
        });
    }

    public void SpawnUnits(SpawnData data = null)   //  Рефакторинг
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();
        var boss = CreatureFactory.Instance.CreateObject(creatureObject, typeof(Gasadokuro));
        boss.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);
        boss.OnObjectDeath.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)); //  Костыль
        boss.GetComponent<StateChanger>().SetTarget(_target);

        FindObjectOfType<MobsHpBarManager>().AddCreature(boss);

        _detector.OnPlayerRoomEnterEvent.RemoveListener(player =>
        {
            _target = player;
            SpawnUnits();
        });

        Destroy(creatureObject);
    }

    private Vector2 FindPosition()
    {
        var grid = GetComponentInChildren<Grid>();
        var cell = grid.LocalToWorld(grid.GetComponentInChildren<Tilemap>().localBounds.center);
        return cell;
    }
}
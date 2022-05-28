using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour, ISpawner
{
    public int SpawnedUnitsCount { get; private set; }

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

    public void SpawnUnits(SpawnData data = null)
    {
        data ??= EnemyGenerator.Instance.GenerateRandomUnits();

        _detector.OnPlayerRoomEnterEvent.RemoveListener(player =>
        {
            _target = player;
            SpawnUnits();
        });

        SpawnedUnitsCount = data.Units.Sum(unit => unit.Count);
        foreach (var unitsData in data.Units)
            CreateUnit(unitsData);
    }

    private void CreateUnit(SpawnUnitsData unitsData)
    {
        var type = TypeConvertor.ConvertEnumToType(unitsData.CreatureType);
        var data = CreatureDatabase.Instance.GetDataByType(type);
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = ValidatePosition(data.Prefab.GetComponent<Creature>());

        for (var i = 0; i < unitsData.Count; i++)
        {
            var creature = CreatureFactory.Instance.CreateObject(creatureObject, type);
            GlobalEventManager.Instance.OnEnemyDeathEvent.AddListener(() => SpawnedUnitsCount--);
            creature.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);
            creature.GetComponent<StateChanger>().SetTarget(_target);
            MobsHpBarManager.Instance.AddCreature(creature);
            Debug.Log($"Spawned {creature}");
        }

        Destroy(creatureObject);
    }

    private Vector2 ValidatePosition(Creature creature)
    {
        var size = creature.GetComponent<CapsuleCollider2D>().size;
        var position = GetRandomPosition();

        while (Physics2D
               .CapsuleCastAll(position, size, CapsuleDirection2D.Vertical, 360, Vector2.right, 0)
               .Any(cast => !cast.collider.isTrigger))
            position = GetRandomPosition();

        return position;
    }

    private Vector2 GetRandomPosition()
    {
        var tilemap = _detector.GetComponent<Tilemap>();

        var points = GetCurrentRoomPoints();
        var grid = tilemap.gameObject.GetComponentInParent<Grid>();
        var randomIndex = Random.Range(0, points.Count);
        var point = grid.CellToWorld(new Vector3Int(points[randomIndex].x, points[randomIndex].y, 0));

        return point;
    }

    private List<Vector3Int> GetCurrentRoomPoints()
    {
        var tilemap = _detector.GetComponent<Tilemap>();
        var insidePoints = new List<Vector3Int>();

        foreach (var insidePoint in tilemap.cellBounds.allPositionsWithin)
            if (tilemap.GetTile(insidePoint) != null)
                insidePoints.Add(insidePoint);

        return insidePoints;
    }
}

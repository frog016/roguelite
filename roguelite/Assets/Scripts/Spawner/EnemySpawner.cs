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
        _detector.OnPlayerRoomEnterEvent.AddListener(StartSpawning);
    }

    public void SpawnUnits(SpawnData data = null)
    {
        data ??= EnemyGenerator.Instance.GenerateRandomUnits();

        _detector.OnPlayerRoomEnterEvent.RemoveListener(StartSpawning);

        SpawnedUnitsCount = data.Units.Sum(unit => unit.Count);
        foreach (var unitsData in data.Units)
            CreateUnit(unitsData);
    }

    private void StartSpawning(DamageableObject target)
    {
        _target = target;
        SpawnUnits();
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
            creature.OnObjectDeath.AddListener(() => SpawnedUnitsCount--);
            creature.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);
            creature.GetComponent<EnemyStateChanger>().SetTarget(_target);
            MobsHpBarManager.Instance.AddCreature(creature);
            Debug.Log($"Spawned {creature} in position {creature.transform.position}");
        }

        Destroy(creatureObject);
    }

    private Vector2 ValidatePosition(Creature creature)
    {
        var size = creature.GetComponent<CapsuleCollider2D>().size;
        var position = GetRandomPosition();

        while (Physics2D
               .CapsuleCastAll(new Vector3(position.x, position.y), size, CapsuleDirection2D.Vertical, 360, Vector2.right, 0)
               .Any(cast => !cast.collider.isTrigger))
            position = GetRandomPosition();

        var grid = GetComponentInChildren<Grid>();
        var a = grid.CellToWorld(position);
        return a;
    }

    private Vector3Int GetRandomPosition()
    {
        var points = GetCurrentRoomPoints();
        var randomIndex = Random.Range(0, points.Count);

        return points[randomIndex];
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

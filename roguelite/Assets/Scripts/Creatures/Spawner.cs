using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using Edgar.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Spawner : SingletonObject<Spawner>
{
    [SerializeField] private Vector2Int _unitsRange;
    [SerializeField] private Vector2Int _currentUnitRange;

    private List<Vector3Int> _currentRoomPoints;

    protected override void Awake()
    {
        _currentRoomPoints = new List<Vector3Int>();
    }

    private void Start()
    {
        RoomManager.Instance.OnRoomEnter.AddListener(GetCurrentRoomPoints);
        RoomManager.Instance.OnRoomEnter.AddListener(() => SpawnUnits());
        RoomManager.Instance.OnRoomExit.AddListener(() => Destroy(RoomManager.Instance.CurrentRoom.RoomTemplateInstance.GetComponentInChildren<RoomDetector>()));
    }

    public void SpawnUnits(SpawnData data = null)
    {
        data ??= GenerateRandomUnits();

        foreach (var unitsData in data.Units)
            CreateUnits(unitsData);
    }

    private void CreateUnits(SpawnUnitsData unitsData)
    {
        var type = TypeConvertor.ConvertEnumToType(unitsData.CreatureType);
        var data = CreatureDatabase.Instance.GetDataByType(type);
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = ValidatePosition(data.Prefab.GetComponent<Creature>());

        for (var i = 0; i < unitsData.Count; i++)
            CreatureFactory.Instance.CreateObject(creatureObject, type);

        Destroy(creatureObject);
    }

    private SpawnData GenerateRandomUnits()
    {
        var data = new SpawnData();
        var creatureTypes = Enum.GetNames(typeof(CreatureType))
            .Select(creature => (CreatureType)Enum.Parse(typeof(CreatureType), creature)).ToList();
        creatureTypes.Remove(CreatureType.HeroSamurai);

        var count = Random.Range(_unitsRange.x, _unitsRange.y);
        for (var i = 0; i < count; i++)
        {
            var unitsData = new SpawnUnitsData(
                creatureTypes[Random.Range(0, creatureTypes.Count)],
                Random.Range(_currentUnitRange.x, _currentUnitRange.y));
            data.Units.Add(unitsData);
        }

        return data;
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
        var tilemap = RoomManager.Instance.CurrentRoom.RoomTemplateInstance
            .GetComponentInChildren<RoomDetector>().gameObject
            .GetComponent<Tilemap>();

        var grid = tilemap.gameObject.GetComponentInParent<Grid>();
        var randomIndex = Random.Range(0, _currentRoomPoints.Count);
        var point = grid.CellToWorld(new Vector3Int(_currentRoomPoints[randomIndex].x, _currentRoomPoints[randomIndex].y, 0));

        return point;
    }

    private void GetCurrentRoomPoints()
    {
        var tilemap = RoomManager.Instance.CurrentRoom.RoomTemplateInstance
            .GetComponentInChildren<RoomDetector>().gameObject
            .GetComponent<Tilemap>();
        var insidePoints = tilemap.cellBounds.allPositionsWithin;

        foreach (var insidePoint in insidePoints)
            if (tilemap.GetTile(insidePoint) != null)
                _currentRoomPoints.Add(insidePoint);
    }

    private void OnDestroy()
    {
        RoomManager.Instance.OnRoomEnter.RemoveListener(() => SpawnUnits());
        RoomManager.Instance.OnRoomExit.RemoveListener(() => Destroy(RoomManager.Instance.CurrentRoom.RoomTemplateInstance.GetComponent<RoomDetector>()));
    }
}

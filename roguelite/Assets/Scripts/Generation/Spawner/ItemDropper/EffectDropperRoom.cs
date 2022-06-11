using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EffectDropperRoom : ItemDropperRoomBase
{
    private EffectsAltar _altar;
    private Type _droppableItemType;
    private List<Type> _allEffectsType;

    private void Awake()
    {
        _droppableItemType = typeof(EffectBase);
        ItemName = "Выберите награду у алтаря";
        ItemsCount = 4;

        _altar = PrefabsFinder.FindObjectOfType<EffectsAltar>().GetComponent<EffectsAltar>();
        _allEffectsType = _droppableItemType.Assembly.ExportedTypes.Where(type => _droppableItemType.IsAssignableFrom(type) && !type.IsAbstract).ToList();
    }

    public override void DropItems()
    {
        //var altar = Instantiate(_altar, ValidatePosition(_altar.gameObject), Quaternion.identity);
        var altar = Instantiate(_altar, PlayerSpawner.Instance.Player.transform.position, Quaternion.identity);
        altar.EffectTypes = _allEffectsType;
    }

    private Vector2 ValidatePosition(GameObject gameObject)
    {
        var collider2d = gameObject.GetComponentInChildren<PolygonCollider2D>();
        var size = collider2d.points.Max(point => Vector2.Distance(point, gameObject.transform.position));
        var result = Vector2.right;

        foreach (var position in GetRandomPosition())
        {
            var newPosition = new Vector2(position.x, position.y);
            if (Physics2D
                .CircleCastAll(newPosition, size, Vector2.right, 0)
                .All(cast => cast.collider.isTrigger))
            {
                result = newPosition;
                break;
            }
        }

        return result;
    }

    private IEnumerable<Vector3Int> GetRandomPosition()
    {
        foreach (var point in GetCurrentRoomPoints())
            yield return point;
    }

    private List<Vector3Int> GetCurrentRoomPoints()
    {
        var tilemap = GetComponentInChildren<RoomDetector>().GetComponent<Tilemap>();
        var center = new Vector3Int((int)tilemap.localBounds.center.x, (int)tilemap.localBounds.center.y,
            (int)tilemap.localBounds.center.z);
        var insidePoints = new List<Vector3Int>();

        foreach (var insidePoint in tilemap.cellBounds.allPositionsWithin)
            if (tilemap.GetTile(insidePoint) != null)
                insidePoints.Add(insidePoint);

        return insidePoints.OrderBy(vector => Vector3Int.Distance(vector, center)).ToList();
    }
}

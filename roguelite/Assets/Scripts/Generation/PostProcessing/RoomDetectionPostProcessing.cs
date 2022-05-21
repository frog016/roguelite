using Edgar.Unity;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Room Detection", fileName = "RoomDetectionPostProcessing")]
public class RoomDetectionPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        foreach (var roomInstance in level.RoomInstances)
        {
            var roomTemplateInstance = roomInstance.RoomTemplateInstance;

            var tilemaps = RoomTemplateUtilsGrid2D.GetTilemaps(roomTemplateInstance);

            var floor = tilemaps.Single(x => x.name == "Floor").gameObject;
            AddFloorCollider(floor);

            if (roomInstance.IsCorridor || roomTemplateInstance.GetComponent<PlayerSpawner>() != null)
                continue;

            floor.AddComponent<RoomDetector>();
        }
    }

    private void AddFloorCollider(GameObject floor)
    {
        var tilemapCollider2D = floor.AddComponent<TilemapCollider2D>();
        tilemapCollider2D.usedByComposite = true;

        var compositeCollider2d = floor.AddComponent<CompositeCollider2D>();
        compositeCollider2d.geometryType = CompositeCollider2D.GeometryType.Polygons;
        compositeCollider2d.isTrigger = true;
        compositeCollider2d.generationType = CompositeCollider2D.GenerationType.Manual;

        

        floor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}


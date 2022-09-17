using Edgar.Unity;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Dungeon generator/Custom tilemap layers handler", fileName = "CustomTilemapLayersHandler")]
public class CustomTilemapLayersHandler : TilemapLayersHandlerBaseGrid2D
{
    public override void InitializeTilemaps(GameObject gameObject)
    {
        var grid = gameObject.AddComponent<Grid>();
        grid.cellSize = new Vector3(1, 0.5f, 1);
        grid.cellLayout = GridLayout.CellLayout.Isometric;

        CreateTilemapGameObject("Floor", gameObject, -32768);

        var walls = CreateTilemapGameObject("Walls", gameObject, -32768);
        AddCompositeCollider(walls);
        AddNavMeshModifier(walls);
        //CreateTilemapGameObject("Additional layer 1", gameObject, 2);
        //CreateTilemapGameObject("Additional layer 2", gameObject, 3);
    }

    private GameObject CreateTilemapGameObject(string name, GameObject parentObject, int sortingOrder)
    {
        var tilemapObject = new GameObject(name);
        tilemapObject.transform.SetParent(parentObject.transform);

        var tilemap = tilemapObject.AddComponent<Tilemap>();
        var tilemapRenderer = tilemapObject.AddComponent<TilemapRenderer>();
        tilemapRenderer.sortingOrder = sortingOrder;

        return tilemapObject;
    }

    private void AddCompositeCollider(GameObject tilemapGameObject, bool isTrigger = false)
    {
        var tilemapCollider2D = tilemapGameObject.AddComponent<TilemapCollider2D>();
        tilemapCollider2D.usedByComposite = true;

        var compositeCollider2d = tilemapGameObject.AddComponent<CompositeCollider2D>();
        compositeCollider2d.geometryType = CompositeCollider2D.GeometryType.Polygons;
        compositeCollider2d.isTrigger = isTrigger;

        tilemapGameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void AddNavMeshModifier(GameObject tilemapGameObject)
    {
        var modifier = tilemapGameObject.AddComponent<NavMeshModifier>();
        modifier.overrideArea = true;
        modifier.area = 1;
    }
}

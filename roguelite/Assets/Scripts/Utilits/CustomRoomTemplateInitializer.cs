using Edgar.Unity;
using UnityEditor;
using UnityEngine;

public class CustomRoomTemplateInitializer: RoomTemplateInitializerBaseGrid2D
{
    protected override void InitializeTilemaps(GameObject tilemapsRoot)
    {
        var tilemapLayersHandler = ScriptableObject.CreateInstance<CustomTilemapLayersHandler>();
        tilemapLayersHandler.InitializeTilemaps(tilemapsRoot);
    }

    [MenuItem("Assets/Create/Dungeon generator/Custom room template")]
    public static void CreateRoomTemplatePrefab()
    {
        RoomTemplateInitializerUtilsGrid2D.CreateRoomTemplatePrefab<CustomRoomTemplateInitializer>();
    }
}

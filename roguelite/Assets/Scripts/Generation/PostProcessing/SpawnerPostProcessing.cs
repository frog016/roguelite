using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Spawner", fileName = "SpawnerPostProcessing")]
public class SpawnerPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        foreach (var roomInstance in level.RoomInstances)
        {
            var roomTemplateInstance = roomInstance.RoomTemplateInstance;

            if (roomTemplateInstance.GetComponent<ISpawner>() != null || roomInstance.IsCorridor)
                continue;
            
            roomTemplateInstance.AddComponent<EnemySpawner>();
        }
    }
}

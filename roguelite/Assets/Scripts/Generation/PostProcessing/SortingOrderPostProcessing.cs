using Edgar.Unity;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Sorting order", fileName = "SortingOrderPostProcessing")]
public class SortingOrderPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        foreach (var roomInstance in level.RoomInstances)
        {
            var roomTemplateInstance = roomInstance.RoomTemplateInstance;

            var environment = roomTemplateInstance.transform
                .Cast<Transform>()
                .FirstOrDefault(transformObject => transformObject.GetComponent<Grid>() == null);

            environment?.gameObject.AddComponent<Environment>();
        }
    }
}
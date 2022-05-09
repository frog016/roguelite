using Edgar.Unity;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Edgar/Post processing/Rebaker", fileName = "RebakePostProcessing")]
public class RebakePostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        FindObjectOfType<DungeonGeneratorGrid2D>().OnEndGeneration.AddListener(FindObjectOfType<NavMeshSurface>().BuildNavMesh);
    }
}

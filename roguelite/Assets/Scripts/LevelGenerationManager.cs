using System.Collections;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class LevelGenerationManager : SingletonObject<LevelGenerationManager>
{
    public UnityEvent OnEndGeneration { get; private set; }

    private DungeonGeneratorGrid2D _generator;
    private NavMeshSurface _surface;

    protected override void Awake()
    {
        base.Awake();
        OnEndGeneration = new UnityEvent();
        _generator = FindObjectOfType<DungeonGeneratorGrid2D>();
        _surface = FindObjectOfType<NavMeshSurface>();
    }

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        StartCoroutine(GenerateLevelCoroutine());
    }

    private IEnumerator GenerateLevelCoroutine()
    {
        yield return null;
        _generator.Generate();
        yield return null;
        _surface.BuildNavMesh();
        OnEndGeneration.Invoke();
    }
}

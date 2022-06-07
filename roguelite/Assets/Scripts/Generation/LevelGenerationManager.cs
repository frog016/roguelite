using System.Collections;
using Agava.YandexGames;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class LevelGenerationManager : SingletonObject<LevelGenerationManager>
{
    [SerializeField] private bool _generateOnStart;

    public UnityEvent OnGenerationEndedEvent { get; private set; }

    private Grid _grid;
    private DungeonGeneratorGrid2D _generator;
    private NavMeshSurface _surface;

    protected override void Awake()
    {
        base.Awake();
        YandexGamesSdk.CallbackLogging = true;
        OnGenerationEndedEvent = new UnityEvent();
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
        if (_generateOnStart)
        {
            yield return null; 
            _generator.Generate();
            yield return null;
            _surface.BuildNavMesh();
        }

        OnGenerationEndedEvent.Invoke();
    }
}

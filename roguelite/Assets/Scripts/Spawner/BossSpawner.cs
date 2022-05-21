using UnityEngine;
using UnityEngine.Tilemaps;

public class BossSpawner : SingletonObject<BossSpawner>, ISpawner
{
    protected override void Awake()
    {
        base.Awake();
        LevelGenerationManager.Instance.OnEndGeneration.AddListener(() => SpawnUnits());
    }

    public void SpawnUnits(SpawnData data = null)
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();
        var boss = CreatureFactory.Instance.CreateObject(creatureObject, typeof(Gasadokuro));
        boss.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);

        LevelGenerationManager.Instance.OnEndGeneration.RemoveListener(() => SpawnUnits());
        Destroy(creatureObject);
    }

    private Vector2 FindPosition()
    {
        var grid = GetComponentInChildren<Grid>();
        var cell = grid.LocalToWorld(grid.GetComponentInChildren<Tilemap>().localBounds.center);
        return cell;
    }
}
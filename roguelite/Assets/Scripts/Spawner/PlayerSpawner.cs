using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSpawner : SingletonObject<PlayerSpawner>, ISpawner
{
    public DamageableObject Player { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        LevelGenerationManager.Instance.OnEndGeneration.AddListener(() => SpawnUnits());
    }

    public void SpawnUnits(SpawnData data = null)
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();

        Player = CreatureFactory.Instance.CreateObject(creatureObject, typeof(HeroSamurai));
        Player.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnPlayerDeathEvent.Invoke);
        Camera.main.GetComponent<CameraTracking>().SetObject(Player.transform);

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

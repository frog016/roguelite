using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSpawner : SingletonObject<PlayerSpawner>, ISpawner
{
    public DamageableObject Player { get; private set; }

    private void Start()
    {
        SpawnUnits();
    }

    public void SpawnUnits(SpawnData data = null)
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();

        Player = CreatureFactory.Instance.CreateObject(creatureObject, typeof(HeroSamurai));
        Player.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnPlayerDeathEvent.Invoke);
        Player.OnObjectDeath.AddListener(() => PlayerStatistic.Instance.DeathCount++);
        Camera.main.GetComponent<CameraTracking>().SetObject(Player.transform);

        LevelGenerationManager.Instance.OnGenerationEndedEvent.RemoveListener(() => SpawnUnits());
        Destroy(creatureObject);
    }

    private Vector2 FindPosition()  // Вынести в класс для поиска позиций
    {
        var grid = GetComponentInChildren<Grid>();
        return grid.LocalToWorld(GetComponentInChildren<Tilemap>().localBounds.center);
    }
}

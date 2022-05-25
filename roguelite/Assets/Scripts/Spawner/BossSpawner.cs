using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class BossSpawner : SingletonObject<BossSpawner>, ISpawner
{
    public void SpawnUnits(SpawnData data = null)   //  Рефакторинг
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();
        var boss = CreatureFactory.Instance.CreateObject(creatureObject, typeof(Gasadokuro));
        boss.OnObjectDeath.AddListener(GlobalEventManager.Instance.OnEnemyDeathEvent.Invoke);
        boss.OnObjectDeath.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)); //  Костыль
        boss.GetComponent<StateChanger>().SetTarget(PlayerSpawner.Instance.Player);

        FindObjectOfType<MobsHpBarManager>().AddCreature(boss);
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
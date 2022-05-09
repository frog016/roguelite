using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroSpawn : MonoBehaviour
{
    private Grid _grid;

    private void Awake()
    {
        _grid = GetComponentInChildren<Grid>();
    }

    private void Start()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        var creatureObject = new GameObject("Empty");
        creatureObject.transform.position = FindPosition();

        var hero = CreatureFactory.Instance.CreateObject(creatureObject, typeof(HeroSamurai));
        Camera.main.GetComponent<CameraTracking>().SetObject(hero.transform);

        Destroy(creatureObject);
    }

    private Vector2 FindPosition()
    {
        var cell = _grid.LocalToWorld(_grid.GetComponentInChildren<Tilemap>().localBounds.center);
        return cell;
    }
}

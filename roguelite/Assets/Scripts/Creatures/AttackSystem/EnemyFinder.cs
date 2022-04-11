using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyFinder : MonoBehaviour
{
    private List<DamageableObject> _enemies;
    private HashSet<Collider2D> _myColliders;

    public bool HaveEnemy => _enemies.Count != 0;

    private void Awake()
    {
        _myColliders = new HashSet<Collider2D>(transform.parent.GetComponentsInChildren<Collider2D>());
        _enemies = new List<DamageableObject>();
    }

    public void SetSegmentColliderRadius(float radius)
    {
        var collider = GetComponent<PolygonCollider2D>();
        var points = collider.points.Select(point => point * radius).ToArray();
        collider.points = points;
    }

    public List<DamageableObject> FindEnemy()
    {
        return _enemies;
    }

    private bool IsEnemy(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var enemy = otherCollider.GetComponent<DamageableObject>();
        if (!IsEnemy(otherCollider) || !enemy)
            return;

        _enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        var enemy = otherCollider.GetComponent<DamageableObject>();
        if (!IsEnemy(otherCollider) || !enemy)
            return;

        _enemies.Remove(enemy);
    }
}

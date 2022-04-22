using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsFinder : MonoBehaviour
{
    private MoveController _moveController;
    private HashSet<Collider2D> _myColliders;

    private void Start() //TODO: Отладить геометрию
    {
        _moveController = GetComponentInParent<MoveController>();
        _myColliders = new HashSet<Collider2D>(transform.parent.GetComponentsInChildren<Collider2D>());
    }

    public List<DamageableObject> FindTargetsInSector(float radius, float sectorAngle)
    {
        return FindTargetsInCircle(radius)
            .Where(damageableObject => Vector2.Angle(
                _moveController.Direction, 
                damageableObject.transform.position - transform.position) - sectorAngle / 2 < 1e-10)
            .ToList(); ;
    }

    public List<DamageableObject> FindTargetsInCircle(float radius)
    {
        return Physics2D.CircleCastAll(transform.position, radius, _moveController.Direction, 0)
            .Where(raycast => IsEnemy(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .ToList();
    }

    public List<DamageableObject> FindTargetsInBox(Vector2 size, float distance)
    {
        var angle = Vector2.Angle(Vector2.right, _moveController.Direction);
        return Physics2D.BoxCastAll(transform.position, size, angle, _moveController.Direction)
            .Where(raycast => IsEnemy(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .ToList(); ;
    }

    private bool IsEnemy(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);
}

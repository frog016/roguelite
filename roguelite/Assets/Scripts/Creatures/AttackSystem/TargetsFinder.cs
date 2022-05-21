using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsFinder : MonoBehaviour
{
    private DamageableObject _owner;
    private MoveController _moveController;
    private HashSet<Collider2D> _myColliders;

    private void Awake()
    {
        _owner = GetComponentInParent<DamageableObject>();
        _moveController = _owner.GetComponent<MoveController>();
        _myColliders = new HashSet<Collider2D>(_owner.GetComponentsInChildren<Collider2D>());
    }

    public List<DamageableObject> FindTargetsInSector(float radius, float sectorAngle)
    {
        return FindTargetsInCircle(radius)
            .Where(damageableObject => Vector2.Angle(
                _moveController.Direction, 
                damageableObject.transform.position - transform.position) < sectorAngle / 2)
            .ToList(); ;
    }

    public List<DamageableObject> FindTargetsInCircle(float radius)
    {
        return Physics2D.CircleCastAll(transform.position, radius, _moveController.Direction, 0)
            .Where(raycast => IsOtherCollider(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .Where(damageableObject => 
                EnemyDetector.Instance.IsEnemy(_owner.GetType(), damageableObject.GetType()))
            .ToList();
    }

    public List<DamageableObject> FindTargetsInBox(Vector2 size, float distance)
    {
        var angle = Vector2.Angle(Vector2.right, _moveController.Direction);
        return Physics2D.BoxCastAll(transform.parent.position, size, angle, _moveController.Direction)
            .Where(raycast => IsOtherCollider(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .Where(damageableObject => 
                EnemyDetector.Instance.IsEnemy(_owner.GetType(), damageableObject.GetType()))
            .ToList(); ;
    }

    private bool IsOtherCollider(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);
}

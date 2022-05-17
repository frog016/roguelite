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

    public List<DamageableObject> FindTargetsInSector(float radius, float sectorAngle) // TODO: Работает верно
    {
        return FindTargetsInCircle(radius)
            .Where(damageableObject => Vector2.Angle(
                _moveController.Direction, 
                damageableObject.transform.position - transform.parent.position) < sectorAngle / 2)
            .ToList(); ;
    }

    public List<DamageableObject> FindTargetsInCircle(float radius, bool isAround = true) // TODO: Работает верно
    {
        var position = transform.parent.position;
        if (!isAround)
            position *= (new Vector3(radius, radius, 0) * _moveController.Direction);
        return Physics2D.CircleCastAll(position, radius, _moveController.Direction, 0)
            .Where(raycast => IsEnemy(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .ToList();
    }

    public List<DamageableObject> FindTargetsInBox(Vector2 size, float distance)
    {
        var angle = Vector2.Angle(Vector2.right, _moveController.Direction);
        return Physics2D.BoxCastAll(transform.parent.position, size, angle, _moveController.Direction)
            .Where(raycast => IsEnemy(raycast.collider))
            .Select(raycast => raycast.transform.GetComponent<DamageableObject>())
            .Where(damageableObject => damageableObject != null)
            .ToList(); ;
    }

    private bool IsEnemy(Collider2D otherCollider) => !_myColliders.Contains(otherCollider);
}

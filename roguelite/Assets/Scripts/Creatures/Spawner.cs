using Edgar.Unity;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    private Vector2 ValidatePosition(Creature creature)
    {
        var size = creature.GetComponent<CapsuleCollider2D>().size;
        var position = GetRandomPosition();

        while (Physics2D
            .CapsuleCastAll(position, size, CapsuleDirection2D.Vertical, 360, Vector2.right, 0)
            .Any(cast => !cast.collider.isTrigger))
            position = GetRandomPosition();

        return position;        
    }

    private Vector2 GetRandomPosition()
    {
        var allPoints = RoomManager.Instance.CurrentRoom.OutlinePolygon.GetAllPoints();
        var randomIndex = Random.Range(0, allPoints.Count + 1);
        var point = allPoints[randomIndex];
        var position = new Vector2(point.x + Random.Range(-0.5f, 0.5f), point.y + Random.Range(-0.5f, 0.5f));
        return position;
    }
}

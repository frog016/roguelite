using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomSeparator : MonoBehaviour
{
    public void SeparateRooms(List<Room> rooms)
    {
        foreach (var room in rooms)
        {
            var rigidbody = room.gameObject.AddComponent<Rigidbody2D>();
            var boxCollider = room.gameObject.AddComponent<BoxCollider2D>();

            rigidbody.gravityScale = 0;
            rigidbody.freezeRotation = true;
            rigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;

            boxCollider.size = room.Size;
        }
        //StartCoroutine(WaitEndSeparation(rooms));
    }

    private IEnumerator WaitEndSeparation(List<Room> rooms)
    {
        var roomsRb = rooms.Select(room => room.GetComponent<Rigidbody2D>());
        yield break;

        foreach (var room in rooms)
        {
            Destroy(room.GetComponent<Rigidbody2D>());
            Destroy(room.GetComponent<BoxCollider2D>());
            room.transform.localScale = new Vector3(room.Size.x, room.Size.y);
        }
    }
}

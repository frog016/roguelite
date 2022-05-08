using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class RoomDetector : MonoBehaviour
{
    private RoomInstanceGrid2D _thisRoom;

    private void Awake()
    {
        _thisRoom = GetComponentInParent<RoomInfoGrid2D>().RoomInstance;
        Debug.Log(_thisRoom);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        RoomManager.Instance.EnterInRoom(_thisRoom);
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        RoomManager.Instance.ExitFormRoom();
    }
}

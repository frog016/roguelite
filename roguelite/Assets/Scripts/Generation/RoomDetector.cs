using Edgar.Unity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class RoomDetector : MonoBehaviour
{
    public UnityEvent<DamageableObject> OnPlayerRoomEnterEvent { get; private set; }

    private RoomInstanceGrid2D _thisRoom;

    private void Awake()
    {
        _thisRoom = GetComponentInParent<RoomInfoGrid2D>().RoomInstance;
        OnPlayerRoomEnterEvent = new UnityEvent<DamageableObject>();
        Debug.Log(_thisRoom);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var player = otherCollider.GetComponent<HeroSamurai>();
        if (player == null)
            return;

        OnPlayerRoomEnterEvent.Invoke(player);
        RoomManager.Instance.EnterInRoom(_thisRoom);
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        RoomManager.Instance.ExitFormRoom();
    }
}

using System.Collections;
using Edgar.Unity;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private RoomDetector _detector;
    private Collider2D collider2D;
    private SpriteRenderer _renderer;

    private void Start()
    {
        Debug.Log("Lock");
        _detector = transform.parent.parent.GetComponentInChildren<RoomDetector>();
        _detector.OnPlayerRoomEnterEvent.AddListener(LockDoor);
        Debug.Log(_detector);
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DestroyDoor);
        gameObject.SetActive(false);

        collider2D = GetComponent<Collider2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void LockDoor(DamageableObject player)
    {
        Invoke(nameof(LockRoomCoroutine), 0.5f);
        //StartCoroutine(LockRoomCoroutine());
    }

    private void DestroyDoor()
    {
        if (RoomManager.Instance.CurrentRoom.RoomTemplateInstance != _detector.GetComponentInParent<RoomTemplateSettingsGrid2D>().gameObject)
            return;

        Debug.Log("DESTROY");
        _detector.OnPlayerRoomEnterEvent.RemoveListener(LockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.RemoveListener(DestroyDoor);
        Debug.Log(GlobalEventManager.Instance.OnRoomClearedEvent.GetPersistentEventCount());
        Destroy(gameObject);
    }

    private void LockRoomCoroutine()
    {
        gameObject.SetActive(true);
    }
}

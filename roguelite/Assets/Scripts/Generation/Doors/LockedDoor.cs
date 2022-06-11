using Edgar.Unity;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private RoomDetector _detector;

    private void Start()
    {
        _detector = transform.parent.parent.GetComponentInChildren<RoomDetector>();

        _detector.OnPlayerRoomEnterEvent.AddListener(LockDoor);
        _detector.OnPlayerRoomExitEvent.AddListener(UnlockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DestroyDoor);

        gameObject.SetActive(false);
    }

    private void LockDoor(DamageableObject player)
    {
        Invoke(nameof(LockRoomCoroutine), 0.8f);
    }

    private void UnlockDoor(DamageableObject player)
    {
        gameObject.SetActive(false);
    }

    private void DestroyDoor()
    {
        if (RoomManager.Instance.CurrentRoom.RoomTemplateInstance != _detector.GetComponentInParent<RoomTemplateSettingsGrid2D>().gameObject)
            return;

        _detector.OnPlayerRoomEnterEvent.RemoveListener(LockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.RemoveListener(DestroyDoor);

        Destroy(gameObject);
    }

    private void LockRoomCoroutine()
    {
        gameObject.SetActive(true);
    }
}

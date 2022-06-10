using System.Collections;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private RoomDetector _detector;

    private void Start()
    {
        _detector = transform.parent.parent.GetComponentInChildren<RoomDetector>();
        _detector.OnPlayerRoomEnterEvent.AddListener(LockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DestroyDoor);
        gameObject.SetActive(false);
    }

    private void LockDoor(DamageableObject player)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        gameObject.SetActive(true);
        StartCoroutine(LockRoomCoroutine());
    }

    private void DestroyDoor()
    {
        _detector.OnPlayerRoomEnterEvent.RemoveListener(LockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.RemoveListener(DestroyDoor);
        Destroy(gameObject);
    }

    private IEnumerator LockRoomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}

using System.Collections;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private RoomDetector _detector;
    private Collider2D collider2D;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _detector = transform.parent.parent.GetComponentInChildren<RoomDetector>();
        _detector.OnPlayerRoomEnterEvent.AddListener(LockDoor);
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DestroyDoor);
        gameObject.SetActive(false);

        collider2D = GetComponent<Collider2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void LockDoor(DamageableObject player)
    {
        collider2D.enabled = false;
        _renderer.enabled = false;
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
        yield return new WaitForSeconds(0.5f);
        collider2D.enabled = true;
        _renderer.enabled = true;
    }
}

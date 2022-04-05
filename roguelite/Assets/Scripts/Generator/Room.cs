using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2Int Size { get; private set; }

    private Vector2 _position;

    public void InitializeRoom(Vector2Int center, Vector2Int size)
    {
        _position = center;
        Size = size;
        transform.position = _position;

        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}

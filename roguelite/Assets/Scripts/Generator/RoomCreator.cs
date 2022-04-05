using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Vector2 _ellipseParameters;
    [SerializeField] private GameObject _roomPrefab;

    public Room CreateRoom()
    {
        var roomObject = Instantiate(_roomPrefab);
        var room = roomObject.GetComponent<Room>();
        var size = GetRandomPointInEllipse();

        room.InitializeRoom(GetRandomPointInEllipse(), new Vector2Int(RoundToCell(size.x), RoundToCell(size.y)));
        return room;
    }

    private Vector2Int GetRandomPointInEllipse()
    {
        var angle = 2 * Mathf.PI * Random.Range(0f, 1f);
        var randomValue = Random.Range(0f, 1f) + Random.Range(0f, 1f);
        var part = randomValue > 1 ? 2 - randomValue : randomValue;
        return new Vector2Int(
            Mathf.RoundToInt(_ellipseParameters.x * _radius * part * Mathf.Cos(angle)),
            Mathf.RoundToInt(_ellipseParameters.y * _radius * part * Mathf.Sin(angle)));
    }

    private int RoundToCell(int value)
    {
        if (value == 0)
            value += 1;
        return Mathf.Abs(value);
    }
}

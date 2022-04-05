using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RoomSeparator), typeof(RoomCreator))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private float _mainRoomCoefficient;

    private List<Room> _rooms;
    private RoomCreator _roomCreator;
    private RoomSeparator _roomSeparator;

    private void Awake()
    {
        _rooms = new List<Room>();
        _roomCreator = GetComponent<RoomCreator>();
        _roomSeparator = GetComponent<RoomSeparator>();
    }

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        var roomsCount = Random.Range(10, 30);
        for (var i = 0; i < roomsCount; i++)
            _rooms.Add(_roomCreator.CreateRoom());
        _roomSeparator.SeparateRooms(_rooms);
        SelectRooms();
    }

    private void SelectRooms()
    {
        var sizes = _rooms.Select(room => room.Size).ToList();
        var meanWidth = _mainRoomCoefficient * sizes.Sum(size => size.x) / sizes.Count;
        var meanHeight = _mainRoomCoefficient * sizes.Sum(size => size.y) / sizes.Count;
        _rooms = _rooms.Where(room => room.Size.x >= meanWidth && room.Size.y >= meanHeight).ToList();
    }
}

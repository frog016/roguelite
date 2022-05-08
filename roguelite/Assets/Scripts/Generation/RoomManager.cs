using Edgar.Unity;
using UnityEngine;
using UnityEngine.Events;

public class RoomManager : SingletonObject<RoomManager>
{
    public RoomInstanceGrid2D CurrentRoom { get; private set; }

    public UnityEvent OnRoomEnter { get; private set; }
    public UnityEvent OnRoomExit { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        OnRoomEnter = new UnityEvent();
        OnRoomExit = new UnityEvent();
    }

    public void EnterInRoom(RoomInstanceGrid2D room)
    {
        CurrentRoom = room;
        Debug.Log(CurrentRoom.Room.name);
        OnRoomEnter.Invoke();
    }

    public void ExitFormRoom()
    {
        OnRoomExit.Invoke();
    }
}

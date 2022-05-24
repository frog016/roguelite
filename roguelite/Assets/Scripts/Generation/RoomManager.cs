using Edgar.Unity;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DropItemsAfterRoom);
    }

    public void EnterInRoom(RoomInstanceGrid2D room)
    {
        CurrentRoom = room;
        OnRoomEnter.Invoke();
    }

    public void ExitFormRoom()
    {
        OnRoomExit.Invoke();
    }

    private void DropItemsAfterRoom()
    {
        CurrentRoom.RoomTemplateInstance.GetComponent<ItemDropperRoomBase>().DropItems();
    }
}

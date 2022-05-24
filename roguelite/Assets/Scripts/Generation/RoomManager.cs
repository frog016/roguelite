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
        GlobalEventManager.Instance.OnPlayerDeathEvent.AddListener(Lose);
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

    private void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void DropItemsAfterRoom()
    {
        CurrentRoom.RoomTemplateInstance.GetComponent<ItemDropperRoomBase>().DropItems();
    }
}

using System.Collections;
using System.Collections.Generic;
using Edgar.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoomManager : SingletonObject<RoomManager>
{
    public RoomInstanceGrid2D CurrentRoom { get; private set; }

    public UnityEvent OnRoomEnter { get; private set; }
    public UnityEvent OnRoomExit { get; private set; }

    private TextMeshProUGUI _text;

    protected override void Awake()
    {
        base.Awake();
        OnRoomEnter = new UnityEvent();
        OnRoomExit = new UnityEvent();
    }

    private void Start()
    {
        _text = FindObjectOfType<ItemDroppingText>().Text;
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
        var itemDropperRoomBase = CurrentRoom.RoomTemplateInstance.GetComponent<ItemDropperRoomBase>();
        _text.text = $"Вам выпало {itemDropperRoomBase.GetType().Name}";

        itemDropperRoomBase.DropItems();
        StartCoroutine(DeleteText());
    }

    private IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(2f);
        _text.text = "";
    }
}
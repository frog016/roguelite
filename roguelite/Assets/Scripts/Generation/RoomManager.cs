using System;
using System.Linq;
using Edgar.Unity;
using UnityEngine.Events;
using Random = UnityEngine.Random;

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
        GlobalEventManager.Instance.OnRoomClearedEvent.AddListener(DropRandomEffect);
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

    private void DropRandomEffect() //  Переместить в EffectDropper
    {
        var effectsTypes = Enum.GetNames(typeof(EffectType))
            .Select(creature => (EffectType)Enum.Parse(typeof(EffectType), creature)).ToList();
        var randomEffect = EffectType.FireEffect;//effectsTypes[Random.Range(0, effectsTypes.Count)];
        EffectFactory.Instance.CreateObject(FindObjectOfType<HeroSamurai>().gameObject,
            TypeConvertor.ConvertEnumToType(randomEffect));
    }
}

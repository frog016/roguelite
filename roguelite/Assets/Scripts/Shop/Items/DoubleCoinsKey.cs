public class DoubleCoinsKey : Item
{
    protected override void Start()
    {
        RoomManager.Instance.OnRoomEnter.AddListener(UseItem);
    }

    protected override void UseItem()
    {
        if (_usesCount <= 0)
        {
            RoomManager.Instance.OnRoomEnter.RemoveListener(UseItem);
        }

        var moneyDropper = RoomManager.Instance.CurrentRoom.RoomTemplateInstance.GetComponent<MoneyDropperRoom>();
        if (moneyDropper == null)
            return;

        moneyDropper.ItemsCount *= 2;
        _usesCount--;

        Destroy(this);
    }
}

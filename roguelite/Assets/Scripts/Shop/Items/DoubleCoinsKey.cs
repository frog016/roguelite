public class DoubleCoinsKey : Item
{
    protected override void StartUse()
    {
        RoomManager.Instance.OnRoomEnter.AddListener(UseItem);
    }

    protected override void UseItem()
    {
        if (_itemData.UsesCount <= 0)
        {
            RoomManager.Instance.OnRoomEnter.RemoveListener(UseItem);
        }

        var moneyDropper = RoomManager.Instance.CurrentRoom.RoomTemplateInstance.GetComponent<MoneyDropperRoom<MoneyWallet, MoneyDropperData>>();
        if (moneyDropper == null)
            return;

        moneyDropper.CoinsCount *= 2;
        _itemData.UsesCount--;

        Destroy(this);
    }
}

public class ItemCard : Card
{
    public override void LoadInfo(Data data)
    {
        var itemDataInfo = data as ItemDataInfo;

        _icon.sprite = itemDataInfo?.Sprite;
        _icon.SetNativeSize();
        _description.text = itemDataInfo?.Description;
    }
}

public class EffectCard : Card
{
    public override void LoadInfo(Data data)
    {
        var effectDataInfo = data as EffectDataInfo;

        _icon.sprite = effectDataInfo?.Sprite;
        _description.text = effectDataInfo?.Description;
    }
}

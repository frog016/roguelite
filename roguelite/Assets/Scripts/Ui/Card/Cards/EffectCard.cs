public class EffectCard : Card
{
    public override void LoadInfo(Info data)
    {
        var effectDataInfo = data as EffectInfo;

        _icon.sprite = effectDataInfo?.Sprite;
        _description.text = effectDataInfo?.Description;
    }
}

using TMPro;
using UnityEngine;

public class ItemCard : Card
{
    [SerializeField] private TextMeshProUGUI _costText;

    public override void LoadInfo(Info data)
    {
        var itemDataInfo = data as ItemInfo;

        _icon.sprite = itemDataInfo.Sprite;
        _icon.SetNativeSize();
        _description.text = itemDataInfo.Description;
        _costText.text = itemDataInfo.Cost.ToString();
    }
}

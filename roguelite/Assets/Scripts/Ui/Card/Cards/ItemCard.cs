using TMPro;
using UnityEngine;

public class ItemCard : Card
{
    [SerializeField] private TextMeshProUGUI _costText;

    public override void LoadInfo(Data data)
    {
        var itemDataInfo = data as ItemDataInfo;

        _icon.sprite = itemDataInfo?.Sprite;
        _icon.SetNativeSize();
        _description.text = itemDataInfo?.Description;
        _costText.text = itemDataInfo?.Cost.ToString();
    }
}

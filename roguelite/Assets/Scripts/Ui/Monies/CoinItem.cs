using TMPro;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
    }
}

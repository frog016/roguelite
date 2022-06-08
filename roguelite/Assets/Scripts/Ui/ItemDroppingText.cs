using TMPro;
using UnityEngine;

public class ItemDroppingText : MonoBehaviour
{
    public TextMeshProUGUI Text { get; private set; }

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
}

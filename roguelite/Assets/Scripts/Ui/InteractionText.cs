using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InteractionText : MonoBehaviour
{
    public TextMeshProUGUI Text { get; private set; }

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _description;

    public abstract void LoadInfo(Info data);
}

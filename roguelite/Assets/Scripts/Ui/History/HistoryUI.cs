using UnityEngine;

[CreateAssetMenu(menuName = "History/HistoryUI", fileName = "HistoryUI")]
public class HistoryUI : ScriptableObject
{
    [Header("History")]
    [SerializeField] private bool _historyIsShown;

    [Header("Controls")]
    [SerializeField] private bool _controlsIsShown;

    public bool HistoryIsShown { get => _historyIsShown; set => _historyIsShown = value; }
    public bool ControlsIsShown { get => _controlsIsShown; set => _controlsIsShown = value; }
}

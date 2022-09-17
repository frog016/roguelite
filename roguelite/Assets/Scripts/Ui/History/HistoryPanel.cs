using System.Collections;
using UnityEngine;

public class HistoryPanel : MonoBehaviour
{
    [SerializeField] private HistoryUI _ui;
    [SerializeField] private GameObject _historyPanel;
    [SerializeField] private GameObject _controlsPanel;

    private void Start()
    {
        StartCoroutine(ShowPanels());
    }

    private IEnumerator ShowPanels()
    {
        PauseManager.Instance.Stop();
        if (!_ui.HistoryIsShown)
        {
            _historyPanel.SetActive(true);
            _ui.HistoryIsShown = true;
            yield return new WaitUntil(() => Input.anyKeyDown);
            _historyPanel.SetActive(false);
        }

        yield return new WaitForSecondsRealtime(1f);

        if (!_ui.ControlsIsShown)
        {
            _controlsPanel.SetActive(true);
            _ui.ControlsIsShown = true;
            yield return new WaitUntil(() => Input.anyKeyDown);
            _controlsPanel.SetActive(false);
        }
        PauseManager.Instance.Continue();
    }
}

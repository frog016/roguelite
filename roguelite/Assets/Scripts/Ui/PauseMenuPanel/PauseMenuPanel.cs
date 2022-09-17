using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPanel : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _menuButton;

    [Header("Effect information")]
    [SerializeField] private GameObject _effectsInfo;
    [SerializeField] private Button _effectsInfoButton;

    private void Start()
    {
        ChooseMenuPanel();
        gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        PauseManager.Instance.Stop();
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PauseManager.Instance.Continue();
    }

    public void ChooseMenuPanel()
    {
        _effectsInfo.SetActive(false);
        _effectsInfoButton.GetComponent<ButtonToggle>().SetOff();
        
        _menu.SetActive(true);
        _menuButton.GetComponent<ButtonToggle>().SetOn();
    }

    public void ChooseEffectsInfoPanel()
    {
        _menu.SetActive(false);
        _menuButton.GetComponent<ButtonToggle>().SetOff();

        _effectsInfo.SetActive(true);
        _effectsInfoButton.GetComponent<ButtonToggle>().SetOn();
    }
}

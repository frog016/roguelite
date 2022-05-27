using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    private GameObject _stateOn;
    private GameObject _stateOff;

    private void Awake()
    {
        var objects = GetComponentsInChildren<Image>();
        _stateOff = objects[0].gameObject;
        _stateOn = objects[1].gameObject;
    }

    public void SetOn()
    {
        _stateOff.SetActive(false);
        _stateOn.SetActive(true);
    }

    public void SetOff()
    {
        _stateOn.SetActive(false);
        _stateOff.SetActive(true);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class UIInputHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _handledObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _handledObjects[0].GetComponent<PauseMenuPanel>().OpenPanel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSelection : MonoBehaviour
{
    public GameObject LeftWing;
    public GameObject RightWing;

    private void Start()
    {
        LeftWing.SetActive(false);
        RightWing.SetActive(false);
    }
    public void OnPointEnter()
    {
        LeftWing.SetActive(true);
        RightWing.SetActive(true);
    }
    public void OnPointExit()
    {
        LeftWing.SetActive(false);
        RightWing.SetActive(false);
    }
}

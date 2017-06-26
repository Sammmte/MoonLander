using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : GameButton
{
    [SerializeField]
    GameObject newPanel;

    [SerializeField]
    GameObject currentPanel;

    public void OpenOrClose()
    {
        if(newPanel.activeSelf == true)
        {
            newPanel.SetActive(false);
            currentPanel.SetActive(true);
        }
        else
        {
            newPanel.SetActive(true);
            currentPanel.SetActive(false);
        }
    }

}

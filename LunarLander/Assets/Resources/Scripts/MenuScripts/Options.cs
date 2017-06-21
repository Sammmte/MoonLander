using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : GameButton
{

    [SerializeField]
    GameObject optionPanel;

    [SerializeField]
    GameObject openPanel;

    public void OpenOrClose()
    {
        if(optionPanel.activeSelf == true)
        {
            optionPanel.SetActive(false);
            openPanel.SetActive(true);
        }
        else
        {
            optionPanel.SetActive(true);
            openPanel.SetActive(false);
        }
    }

}

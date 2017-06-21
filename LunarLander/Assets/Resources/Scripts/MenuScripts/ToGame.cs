using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGame : GameButton
{

    [SerializeField]
    GameObject gamePanel;

    [SerializeField]
    GameObject openPanel;

    public void OpenOrClosePanel()
    {
        if (gamePanel.activeSelf == true)
        {
            gamePanel.SetActive(false);
            openPanel.SetActive(true);
        }
        else
        {
            gamePanel.SetActive(true);
            openPanel.SetActive(false);
        }
    }

    public void To3DMode()
    {
        SceneManager.LoadScene("3DMode");
    }

    public void ToRunMode()
    {
        SceneManager.LoadScene("2DMode");
    }

}

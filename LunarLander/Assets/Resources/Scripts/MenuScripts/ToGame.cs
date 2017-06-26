using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGame : GameButton
{
    public void To3DMode()
    {
        SceneManager.LoadScene("3DMode");
    }

    public void To2DMode()
    {
        SceneManager.LoadScene("2DMode");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

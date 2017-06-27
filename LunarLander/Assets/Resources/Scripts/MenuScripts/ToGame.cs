using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGame : GameButton
{
    [SerializeField]
    string sceneName;

    public void ToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
       

}

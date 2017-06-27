using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager
{
    static private GameManager instance;
    private HUD hud;

    private List<GameEntity> sceneObjects;

    private Timer toChangeLevel;
    private const float changeLevelDelay = 2f;

    private bool pause;

    private GameManager()
    {
        sceneObjects = new List<GameEntity>();

        SceneManager.sceneLoaded += SetActiveHUD;
        SceneManager.sceneLoaded += GetAllGameEntities;

        toChangeLevel = new Timer();

        Player.onWin = Win;
        Player.onLose = Lose;
    }

    static public GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }

    public void Pause()
    {
        if(pause)
        {
            foreach(GameEntity o in sceneObjects)
            {
                o.gameObject.SetActive(true);
            }

            pause = false;
        }
        else
        {
            foreach (GameEntity o in sceneObjects)
            {
                o.gameObject.SetActive(false);
            }

            pause = true;
        }

        hud.Pause();
    }

    private void Win()
    {
        hud.SetFinalText(true);

        if(!TimerManager.GetInstance().IsSubscribed(toChangeLevel))
        {
            toChangeLevel.AddToManager();
        }

        toChangeLevel.Start(changeLevelDelay, NextLevel);
    }

    private void Lose()
    {
        hud.SetFinalText(false);

        if (!TimerManager.GetInstance().IsSubscribed(toChangeLevel))
        {
            toChangeLevel.AddToManager();
        }

        toChangeLevel.Start(changeLevelDelay, RestartLevel);
    }

    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().name == "2DLevel1")
        {
            SceneManager.LoadScene("2DLevel2");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SetActiveHUD(Scene current, LoadSceneMode load)
    {
        hud = UnityEngine.Object.FindObjectOfType<HUD>();
    }

    private void GetAllGameEntities(Scene current, LoadSceneMode load)
    {
        GameEntity[] aux = GameObject.FindObjectsOfType<GameEntity>();

        foreach(GameEntity o in aux)
        {
            sceneObjects.Add(o);
        }
    }


    
}

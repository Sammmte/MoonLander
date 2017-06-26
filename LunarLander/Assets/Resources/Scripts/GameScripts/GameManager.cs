using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += GetAllGameObjects;

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
        toChangeLevel.Start(changeLevelDelay, NextLevel);
    }

    private void Lose()
    {
        hud.SetFinalText(false);
        toChangeLevel.Start(changeLevelDelay, RestartLevel);
    }

    private void NextLevel()
    {
        Debug.Log("VAMOO");
    }

    private void RestartLevel()
    {
        Debug.Log("COÑOOO");
    }

    private void SetActiveHUD(Scene current, LoadSceneMode load)
    {
        hud = Object.FindObjectOfType<HUD>();
    }

    private void GetAllGameObjects(Scene current, LoadSceneMode load)
    {
        GameEntity[] aux = GameObject.FindObjectsOfType<GameEntity>();

        foreach(GameEntity o in aux)
        {
            sceneObjects.Add(o);
        }
    }
    
}

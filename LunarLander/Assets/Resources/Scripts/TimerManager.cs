using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TimerManager
{

    List<Timer> timers;
    static private TimerManager instance;
	
    private TimerManager()
    {
        timers = new List<Timer>();
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    static public TimerManager GetInstance()
    {
        if(instance == null)
        {
            instance = new TimerManager();
        }

        return instance;
    }

    public void AddTimer(Timer timer)
    {
        timers.Add(timer);
    }

	public void Update () {

        foreach(Timer t in timers)
        {
            if(t.IsActive())
            {
                t.Update();
            }
        }

	}

    private void Clear()
    {
        foreach (Timer t in timers)
        {
            t.Cancel();
        }

        timers.Clear();
    }

    private void onSceneLoaded(Scene scene, LoadSceneMode load)
    {
        if(!Global.IsStartUp())
        {
            Clear();
        }
    }

    public bool IsSubscribed(Timer tim)
    {
        foreach (Timer t in timers)
        {
            if(t == tim)
            {
                return true;
            }
        }

        return false;
    }
}

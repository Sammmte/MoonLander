using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerManager
{

    List<Timer> timers;
    static private TimerManager instance;
	
    private TimerManager()
    {
        timers = new List<Timer>();
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
}

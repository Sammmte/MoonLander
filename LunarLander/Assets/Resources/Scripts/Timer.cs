using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer {

    Action callback;

    private float time;
    private float timeLeft;

    private bool active = false;

    public Timer()
    {
        TimerManager.GetInstance().AddTimer(this);
    }

    public void Start(float _time, Action _callback)
    {
        time = _time;
        timeLeft = _time;
        callback = _callback;

        active = true;


    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            time = 0;
            timeLeft = 0;
            active = false;
            callback();
        }
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public bool IsActive()
    {
        return active;
    }

    public void Cancel()
    {
        time = 0;
        timeLeft = 0;
        active = false;
        callback = null;
    }

    public void AddToManager()
    {
        TimerManager.GetInstance().AddTimer(this);
    }
}

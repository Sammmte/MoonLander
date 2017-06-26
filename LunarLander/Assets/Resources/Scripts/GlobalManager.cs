using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour {
    
    SoundManager soundManager;
    GameManager gameManager;
    TimerManager timerManager;

	void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);

        gameManager = GameManager.GetInstance();

        soundManager = SoundManager.GetInstance();
        soundManager.InitPreferences();
        soundManager.InstantiateAudio();

        timerManager = TimerManager.GetInstance();
    }

    void Update()
    {
        timerManager.Update();
    }
}

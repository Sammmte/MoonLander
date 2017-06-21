using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSoundManager : MonoBehaviour {
    
    SoundManager soundManager;

	void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);

        soundManager = SoundManager.GetInstance();
        soundManager.InitPreferences();
        soundManager.InstantiateAudio();

        SceneManager.sceneLoaded += Clear;
    }

    void Clear(Scene current, LoadSceneMode m)
    {
        if(!Global.IsStartUp())
        {
            Debug.Log("hola");
            soundManager.soundsList.Clear();
        }
    }
}

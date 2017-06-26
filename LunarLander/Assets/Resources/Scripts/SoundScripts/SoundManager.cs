using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SoundManager {

    static private SoundManager instance;

    public SoundsData soundsList;

    private string soundKeyword = "sound";
    private string volumeKeyword = "volume";
    private bool soundOn;
    private float soundVolume;

    private SoundManager() 
    {
        soundsList = new SoundsData();
        SceneManager.sceneLoaded += Clear;
    }

    static public SoundManager GetInstance()
    {
        if(instance == null)
        {
            instance = new SoundManager();
        }

        return instance;
    }

    public void InitPreferences()
    {
        soundOn = Convert.ToBoolean(PlayerPrefs.GetInt(soundKeyword, 1));
        soundVolume = PlayerPrefs.GetFloat(volumeKeyword, 1);
    }

    public void InstantiateAudio()
    {
        soundsList.InstantiateAudio();
    }

    public void SoundOnOff()
    {
        if (soundOn)
        {
            soundOn = false;
        }
        else
        {
            soundOn = true;
        }

        PlayerPrefs.SetInt(soundKeyword, Convert.ToInt32(soundOn));

        soundsList.UpdateAudios();
    }

    public void SetSoundVolume(float value)
    {
        soundVolume = value;

        PlayerPrefs.SetFloat(volumeKeyword, value);

        soundsList.UpdateAudios();
    }

    public bool IsSoundActive()
    {
        return soundOn;
    }

    public float GetVolume()
    {
        return soundVolume;
    }

    void Clear(Scene current, LoadSceneMode m)
    {
        if (!Global.IsStartUp())
        {
            soundsList.Clear();
        }
    }
}

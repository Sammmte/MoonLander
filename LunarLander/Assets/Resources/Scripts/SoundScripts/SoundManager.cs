using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SoundManager {

    static private SoundManager instance;
    List<ComplexAudio> activeSources;

    public SoundsData soundsList;

    private string soundKeyword = "sound";
    private string volumeKeyword = "volume";

    private bool soundOn;
    private float soundVolume;

    private SoundManager() 
    {
        soundsList = new SoundsData();
        soundsList.LoadAudio();
        
        SceneManager.sceneLoaded += SetNewAudios;
        SceneManager.sceneLoaded += OnLoadedClips;
    }

    static public SoundManager GetInstance()
    {
        if(instance == null)
        {
            instance = new SoundManager();
        }

        return instance;
    }

    void SetActive(bool really)
    {
        foreach(ComplexAudio c in activeSources)
        {
            c.GetAudioSource().enabled = really;
        }
    }

    void SetVolume(float value)
    {
        foreach (ComplexAudio c in activeSources)
        {
            c.GetAudioSource().volume = value;
        }
    }

    public void InitPreferences()
    {
        soundOn = Convert.ToBoolean(PlayerPrefs.GetInt(soundKeyword, 1));
        soundVolume = PlayerPrefs.GetFloat(volumeKeyword, 1);
    }


    public void SoundOnOff()
    {
        if (soundOn)
        {
            soundOn = false;
        }
        else
        {
            PlayClips();
            soundOn = true;
        }

        PlayerPrefs.SetInt(soundKeyword, Convert.ToInt32(soundOn));

        SetActive(soundOn);
    }

    public void ChangeVolume(float value)
    {
        soundVolume = value;

        PlayerPrefs.SetFloat(volumeKeyword, value);

        SetVolume(soundVolume);
    }

    public bool IsSoundActive()
    { 
        return soundOn;
    }

    public float GetVolume()
    {
        return soundVolume;
    }

    void SetNewAudios(Scene current, LoadSceneMode m)
    {
        if (!Global.IsStartUp())
        {
            Clear();
        }

        if (activeSources == null)
        {
            activeSources = new List<ComplexAudio>();
        }
        

        ComplexAudio[] aux = GameObject.FindObjectsOfType<ComplexAudio>();

        foreach (ComplexAudio o in aux)
        {
            activeSources.Add(o);
        }

        AssignClips();
    }

    void PlayClips()
    {
        foreach (ComplexAudio c in activeSources)
        {
            if(c.GetAudioSource().clip != null)
            {
                c.GetAudioSource().Play();
            }
        }
    }

    void OnLoadedClips(Scene scene, LoadSceneMode load)
    {
        InitPreferences();

        if(soundOn)
        {
            PlayClips();
        }
        else
        {
            SetActive(soundOn);
        }

        SetVolume(soundVolume);
    }

    void AssignClips()
    {
        foreach(ComplexAudio c in activeSources)
        {
            c.Init();
            c.GetAudioSource().clip = soundsList.GetAudioClipByName(c.GetClipName());
        }
    }

    void Clear()
    {
        activeSources.Clear();
    }

    public AudioClip GetAudioClipByName(string name)
    {
        return soundsList.GetAudioClipByName(name);
    }

    public void LoadComplexAudio(ComplexAudio c, string clipName, bool play)
    {
        c.GetAudioSource().clip = soundsList.GetAudioClipByName(clipName);

        activeSources.Add(c);

        if(play)
        {
            c.GetAudioSource().Play();
        }
    }
}

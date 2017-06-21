using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsData {

    Object[] sounds;
    List<AudioSource> activeSources;
    SoundManager soundManager;

    public SoundsData()
    {
        activeSources = new List<AudioSource>();
    }

    public void InstantiateAudio()
    {
        soundManager = SoundManager.GetInstance();
        sounds = Resources.LoadAll("Sounds");
    }

    public AudioClip RegisterAudio(string name, AudioSource source)
    {
        foreach(AudioClip ad in sounds)
        {
            if(ad.name == name)
            {
                activeSources.Add(source);
                InitAudioSource(source);
                return ad;
            }
        }

        return null;
    }

    private void InitAudioSource(AudioSource s)
    {
        s.enabled = soundManager.IsSoundActive();
        s.volume = soundManager.GetVolume();
    }

    public void UpdateAudios()
    {
        foreach(AudioSource a in activeSources)
        {
            a.enabled = soundManager.IsSoundActive();
            a.volume = soundManager.GetVolume();
        }
    }

    public void Clear()
    {
        activeSources.Clear();
    }
}

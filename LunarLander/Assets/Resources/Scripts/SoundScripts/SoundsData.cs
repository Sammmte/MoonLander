using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsData {

    Object[] sounds;

    public void LoadAudio()
    {
        sounds = Resources.LoadAll("Sounds");
    }

    public AudioClip GetAudioClipByName(string name)
    {
        foreach(AudioClip a in sounds)
        {
            if(a.name == name)
            {
                return a;
            }
        }

        return null;
    }
}

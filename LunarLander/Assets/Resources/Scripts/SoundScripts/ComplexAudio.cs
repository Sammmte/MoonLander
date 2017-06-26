using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ComplexAudio : MonoBehaviour{

    AudioSource source;

    [SerializeField]
    string clipName;

    public void Init()
    {
        source = GetComponent<AudioSource>();
    }

    public AudioSource GetAudioSource()
    {
        return source;
    }

    public string GetClipName()
    {
        return clipName;
    }

}

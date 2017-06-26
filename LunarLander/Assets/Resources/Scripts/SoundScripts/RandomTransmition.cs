using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransmition : MonoBehaviour {

    private ComplexAudio audioSource;

    private int transmitionCant = 5;

    private string[] transmitionKeywords;

    private int min = 0;
    private int max = 100;

    private const float constTimer = 5f;

    private Timer timer;

    SoundManager soundManager;

	// Use this for initialization
	void Start () {

        transmitionKeywords = new string[transmitionCant];

        for (int i = 0; i < transmitionKeywords.Length; i++)
        {
            transmitionKeywords[i] = "Transmition" + (i + 1);
        }

        soundManager = SoundManager.GetInstance();

        audioSource = GetComponent<ComplexAudio>();

        timer = new Timer();

        timer.Start(constTimer, Reproduce);
    }

    void Reproduce()
    {
        if (Global.IsPrime(Random.Range(min, max)))
        {
            int dis = (int)Random.Range(0, (float)transmitionCant - 0.01f);
            
            if(audioSource.GetAudioSource().enabled)
                audioSource.GetAudioSource().PlayOneShot(soundManager.GetAudioClipByName(transmitionKeywords[dis]));
        }

        timer.Start(constTimer, Reproduce);
    }
}

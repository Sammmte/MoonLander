using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransmition : MonoBehaviour {

    private AudioSource audioSource;

    private int transmitionCant = 5;

    private string[] transmitionKeywords;

    private int min = 0;
    private int max = 100;

    private const float constTimer = 10f;
    private float timer = constTimer;

    SoundManager soundManager;

	// Use this for initialization
	void Start () {

        transmitionKeywords = new string[transmitionCant];

        for (int i = 0; i < transmitionKeywords.Length; i++)
        {
            transmitionKeywords[i] = "Transmition" + (i + 1);
        }

        soundManager = SoundManager.GetInstance();

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(GetTimer() <= 0)
        { 
            if(Global.IsPrime(Random.Range(min, max)))
            {
                int dis = (int)Random.Range(0, (float)transmitionCant - 0.01f);

                audioSource.PlayOneShot(soundManager.soundsList.RegisterAudio(transmitionKeywords[dis], audioSource));
            }
        }

	}

    float GetTimer()
    {
        if (timer <= 0)
        {
            timer = constTimer;
        }

        timer -= Time.deltaTime;

        return timer;
    }
}

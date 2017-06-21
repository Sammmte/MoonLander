using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproduceMusic : MonoBehaviour {

	void Start () {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = SoundManager.GetInstance().soundsList.RegisterAudio("MenuMusic", audioSource);
        audioSource.Play();
	}
}

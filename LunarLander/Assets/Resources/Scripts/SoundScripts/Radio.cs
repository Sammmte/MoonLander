using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

	void Start () {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = SoundManager.GetInstance().soundsList.RegisterAudio("DeathRadio", audioSource);
        audioSource.Play();
	}
}

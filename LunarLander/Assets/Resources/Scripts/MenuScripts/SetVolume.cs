using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {

    [SerializeField]
    Slider slider;

    private void Start()
    {
        slider.value = SoundManager.GetInstance().GetVolume();
    }

    public void SetSoundVolume()
    {
        SoundManager.GetInstance().SetSoundVolume(slider.value);
    }
}

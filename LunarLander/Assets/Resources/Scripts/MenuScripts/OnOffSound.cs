using UnityEngine;
using UnityEngine.UI;

public class OnOffSound : GameButton
{
    [SerializeField]
    Text buttonText;

    void Start()
    {
        ChangeText();
    }

	public void OnOff()
    {
        SoundManager.GetInstance().SoundOnOff();

        ChangeText();
    }

    private void ChangeText()
    {
        if (SoundManager.GetInstance().IsSoundActive())
        {
            buttonText.text = "On";
        }
        else
        {
            buttonText.text = "Off";
        }
    }
}

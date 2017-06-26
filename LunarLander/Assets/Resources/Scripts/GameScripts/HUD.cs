using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    [SerializeField]
    Text fuel;

    [SerializeField]
    Text altitude;

    [SerializeField]
    Text verticalVel;

    [SerializeField]
    Text horizontalVel;

    [SerializeField]
    Text finalText;

    [SerializeField]
    GameObject pausePanel;

    string winText = "REACHED";
    string loseText = "FAIL";

    [SerializeField]
    Player player;

    void Start()
    {
        finalText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        fuel.text = "Fuel: " + player.GetFuel().ToString();
        altitude.text = "Altitude: " + player.GetAltitude().ToString();
        verticalVel.text = "Vertical Velocity: " + player.GetVerticalVelocity().ToString();
        horizontalVel.text = "Horizontal Velocity: " + player.GetHorizontalVelocity().ToString();
    }

    public void SetFinalText(bool win)
    {
        if(win)
        {
            finalText.text = winText;
        }
        else
        {
            finalText.text = loseText;
        }

        finalText.gameObject.SetActive(true);
    }

    public void Pause()
    {
        if(pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(true);
        }
    }

}

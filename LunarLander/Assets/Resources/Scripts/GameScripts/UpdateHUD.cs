using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHUD : MonoBehaviour {

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
    Player player;

    // Update is called once per frame
    void Update() {

        fuel.text = "Fuel: " + player.GetFuel().ToString();
        altitude.text = "Altitude: " + player.GetAltitude().ToString();
        verticalVel.text = "Vertical Velocity: " + player.GetVerticalVelocity().ToString();
        horizontalVel.text = "Horizontal Velocity: " + player.GetHorizontalVelocity().ToString();

        CheckIsOver();

    }

    void CheckIsOver()
    {
        if (player.IsDead())
        {
            finalText.gameObject.SetActive(true);
            finalText.text = "YOU LOSE";
        }
        else if (player.HasWinned())
        {
            finalText.gameObject.SetActive(true);
            finalText.text = "REACHED";
        }
    }
}

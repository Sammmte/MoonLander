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
    Player player;

	// Update is called once per frame
	void Update () {

        fuel.text = "Fuel: " + player.GetFuel().ToString();
        altitude.text = "Altitude: " + player.GetAltitude().ToString();
        verticalVel.text = "Vertical Velocity: " + player.GetVerticalVelocity().ToString();
        horizontalVel.text = "Horizontal Velocity: " + player.GetHorizontalVelocity().ToString();

	}
}

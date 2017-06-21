using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionButton : GameButton {

    public void SetResolution()
    {
        FilterByName();

        Screen.SetResolution(PlayerPrefs.GetInt(Global.widthResolutionPref, Global.baseWidth),
                            PlayerPrefs.GetInt(Global.heightResolutionPref, Global.baseHeight), 
                            true);
    }

	private void FilterByName()
    {
        switch(this.gameObject.name)
        {
            case "1024x768":
                PlayerPrefs.SetInt(Global.widthResolutionPref, 1024);
                PlayerPrefs.SetInt(Global.heightResolutionPref, 768);
                break;

            case "1280x720":
                PlayerPrefs.SetInt(Global.widthResolutionPref, 1280);
                PlayerPrefs.SetInt(Global.heightResolutionPref, 720);
                break;

            case "1366x768":
                PlayerPrefs.SetInt(Global.widthResolutionPref, 1366);
                PlayerPrefs.SetInt(Global.heightResolutionPref, 768);
                break;

            case "1920x1080":
                PlayerPrefs.SetInt(Global.widthResolutionPref, 1920);
                PlayerPrefs.SetInt(Global.heightResolutionPref, 1080);
                break;
        }
    }
}

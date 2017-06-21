using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private bool pause = false;

    static public void Pause(Player player)
    {
        Rigidbody rb3D = player.GetComponent<Rigidbody>();
        Rigidbody2D rb2D = player.GetComponent<Rigidbody2D>();
        MonoBehaviour mono = player.GetComponent<MonoBehaviour>();

        if(pause)
        {
            mono.enabled = true;

            if (rb2D != null)
            {
                rb2D.isKinematic = false;
            }

            if (rb3D != null)
            {
                rb3D.isKinematic = false;
            }

            pause = false;
        }
        else
        {
            mono.enabled = false;

            if (rb2D != null)
            {
                rb2D.isKinematic = true;
            }

            if (rb3D != null)
            {
                rb3D.isKinematic = true;
            }

            pause = true;
        }
    }
}

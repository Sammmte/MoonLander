using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualInput : MonoBehaviour
{
    [SerializeField]
    Player player;

    void Update()
    {
        VerticalAxis();
        HorizontalAxis();
        Pause();
    }

    private void VerticalAxis()
    {
        player.Impulse(Input.GetAxis("Vertical"));
    }

    private void HorizontalAxis()
    {
        player.Rotate(Input.GetAxis("Horizontal"));
    }

    private void Pause()
    {
        if(Input.GetButtonDown("Pause"))
        {
            GameManager.GetInstance().Pause();
        }
    }
}

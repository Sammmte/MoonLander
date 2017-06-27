using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ship2D : Player {

    private Rigidbody2D rb;

    private float landingVel = 0.35f;
    private Vector2 landingWindow;
    private Vector2 lastVel;
    private const float force = 1.2f;

    // Use this for initialization
    void Start () {

        landingWindow = new Vector2(landingVel, landingVel);
        rb = GetComponent<Rigidbody2D>();
        yBottom = GetComponent<BoxCollider2D>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
        CalculateAltitude();
    }

    override public void Rotate(float rotation)
    {
        rb.AddTorque(-rotation);
    }

    override public void Impulse(float impulse)
    {
        if(fuel > 0)
        {
            rb.AddRelativeForce(new Vector2(0, impulse) * force, ForceMode2D.Impulse);

            if (impulse > 0)
            {
                fuel -= fuelModifier;
            }
        }

        lastVel = rb.velocity;
    }

    private void CheckCollision(string safeLevel)
    {
        if(safeLevel == "Safe" || safeLevel == "Final")
        {
            //si la velocidad no esta dentro de un margen de -1 a 1 en la x o la y...
            if ((lastVel.x < -landingWindow.x || lastVel.x > landingWindow.x) || (lastVel.y < -landingWindow.y || lastVel.y > landingWindow.y))
            {
                GetDestroyed();
            }
            else
            {
                if (safeLevel == "Final")
                {
                    onWin();
                }

                if (fuelCharge)
                {
                    Full();
                }
            }
        }
        else if(safeLevel == "Unsafe")
        {
            GetDestroyed();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<MapZone>() != null)
        {
            CheckCollision(col.gameObject.GetComponent<MapZone>().GetSafeLevel().ToString());
        }
    }

    public override float GetHorizontalVelocity()
    {
        return (float)Math.Round(Mathf.Pow(rb.velocity.x, 2), 3);
    }

    public override float GetVerticalVelocity()
    {
        return (float)Math.Round(Mathf.Pow(rb.velocity.y, 2), 3);
    }

    private void CalculateAltitude()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - yBottom),
                                            Vector2.down, 
                                            Screen.height, 
                                            1 << 8);

        altitude = (float)Math.Round((double)(hit.distance),2);
        //Debug.DrawRay(, Vector3.down, Color.red);
    }
}

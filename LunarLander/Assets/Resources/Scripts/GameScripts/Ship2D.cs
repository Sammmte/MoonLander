using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ship2D : Player {

    private Rigidbody2D rb;

    private Vector2 landingWindow = new Vector2(0.35f, 0.35f);
    private Vector2 lastVel;
    private float force = 1.2f;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();

        yBottom = GetComponent<BoxCollider2D>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
        Impulse();
        CalculateAltitude();
    }

    protected override void Rotate()
    {
        rb.AddTorque(-Input.GetAxis("Horizontal"));
    }

    override protected void Impulse()
    {
        if(fuel > 0)
        {
            rb.AddRelativeForce(new Vector2(0, Input.GetAxis("Vertical")) * force, ForceMode2D.Impulse);
        }

        if(Input.GetButton("Vertical"))
        {
            fuel -= fuelModifier;
        }

        lastVel = rb.velocity;
    }

    private void CheckCollision(Collision2D col)
    {
        
        //si la velocidad no esta dentro de un margen de -1 a 1 en la x o la y...
        if ((lastVel.x < -landingWindow.x || lastVel.x > landingWindow.x) || (lastVel.y < -landingWindow.y || lastVel.y > landingWindow.y))
        {
            GetDestroyed();
        }
        else
        {
            if (col.gameObject.GetComponent<FinalZone>() != null)
            {
                Win();
            }

            if (fuelCharge)
            {
                Full();
            }
        }
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<UnsafeZone>() != null)
        {
            GetDestroyed();
        }
        else if(col.gameObject.GetComponent<SafeZone>() != null)
        {
            CheckCollision(col);
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

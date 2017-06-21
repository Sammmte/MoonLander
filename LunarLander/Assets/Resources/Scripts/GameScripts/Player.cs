using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void OnReturningToMenu();

    protected const float constFuel = 100;
    protected float fuel = constFuel;
    protected float altitude;
    protected float fuelModifier = 0.03f;
    protected float yBottom;

    protected bool fuelCharge = false;

    protected bool win = false;
    protected bool dead = false;

    virtual protected void Impulse() { }
    virtual protected void Rotate() { }

    protected void GetDestroyed()
    {
        dead = true;
        gameObject.SetActive(false);
    }

    protected void Win()
    {
        win = true;
    }

    virtual public float GetHorizontalVelocity()
    {
        return 0;
    }

    virtual public float GetVerticalVelocity()
    {
        return 0;
    }

    public uint GetFuel()
    {
        return (uint)fuel;
    }

    public float GetAltitude()
    {
        return altitude;
    }

    public void SetFuelCharge()
    {
        fuelCharge = true;
    }

    protected void Full()
    {
        fuel = constFuel;
    }

    public bool IsDead()
    {
        return dead;
    }

    public bool HasWinned()
    {
        return win;
    }
}

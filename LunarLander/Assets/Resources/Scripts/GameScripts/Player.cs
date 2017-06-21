using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected float fuel = 100;
    protected float altitude;
    protected float fuelModifier = 0.025f;
    protected float yBottom;

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
}

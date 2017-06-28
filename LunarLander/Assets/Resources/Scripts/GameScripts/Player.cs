using UnityEngine;

public class Player : GameEntity {

    public delegate void OnWin();
    public delegate void OnLose();
    public delegate void OnFuelChanged();

    static public OnWin onWin;
    static public OnLose onLose;
    static public OnFuelChanged onFuelChanged;

    protected const float constFuel = 100;
    protected float fuel = constFuel;
    protected float altitude;
    protected float fuelModifier = 0.03f;
    protected float yBottom;

    protected bool fuelCharge = false;

    virtual public void Impulse(float impulse) { }
    virtual public void Rotate(float rotation) { }

    protected void GetDestroyed()
    {
        gameObject.SetActive(false);

        onLose();
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

    public bool HasCharge()
    {
        return fuelCharge;
    }

    public void SetFuelCharge()
    {
        fuelCharge = true;

        onFuelChanged();
    }

    protected void Full()
    {
        fuel = constFuel;
        fuelCharge = false;

        onFuelChanged();
    }
}

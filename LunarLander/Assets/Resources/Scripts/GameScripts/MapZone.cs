using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : GameEntity {

	public enum SafeLevel
    {
        Safe,
        Unsafe,
        Final
    }

    private SafeLevel safeNumber;

    [SerializeField]
    private int num;

    void Start()
    {
        safeNumber = (SafeLevel)num;
    }

    public SafeLevel GetSafeLevel()
    {
        return safeNumber;
    }
}

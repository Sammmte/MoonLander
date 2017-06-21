using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

static public class Global {

    static public string widthResolutionPref = "widthResolution";
    static public string heightResolutionPref = "heightResolution";

    static public int baseWidth = 1366;
    static public int baseHeight = 768;

    static private bool isStartUp = true;

    static public float RuleOfThree(float dat1, float dat2, float comp)
    {
        return (dat2 * comp) / dat1;
    }
	
    static public bool IsPrime(int a)
    {
        for(int i = 2; i <= a/2; i++)
        {
            if(a % i == 0)
            {
                return true;
            }

        }

        return false;
    }

    static public bool IsStartUp()
    {
        if(isStartUp)
        {
            isStartUp = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}

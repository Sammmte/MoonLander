using UnityEngine;
using UnityEngine.SceneManagement;

static public class Global {

    static public string widthResolutionPref = "widthResolution";
    static public string heightResolutionPref = "heightResolution";

    static public int baseWidth = 1366;
    static public int baseHeight = 768;

    static private bool isStartUp = true;

    static private Timer startUpTimer;

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
            if(startUpTimer == null)
            {
                startUpTimer = new Timer();
                startUpTimer.Start(Time.deltaTime * 2, LockStartUp);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    static private void LockStartUp()
    {
        isStartUp = false;
    }
}

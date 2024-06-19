using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignTrailManager : Singleton<DesignTrailManager>
{
    private string screenName = "designtrail";
    private int currScreen =0;

    public void Next()
    {
        currScreen++;
        WebManager.main.ChangeURL(screenName + "0" + currScreen);
    }

    public void Previous()
    {

        currScreen--;
        WebManager.main.ChangeURL(screenName + "0" + currScreen);
    }

}

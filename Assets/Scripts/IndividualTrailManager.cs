using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTrailManager : Singleton<IndividualTrailManager>
{
    private string screenName = "studenttrail";
    private int currScreen = 0;

    public void Next()
    {
        if(currScreen == 0)
        {
            StartCoroutine(WaitForFirstLoad());
        }
        else
        {

        currScreen++;
        WebManager.main.ChangeURL(screenName + "0" + currScreen);
        }
    }
    public IEnumerator WaitForFirstLoad()
    {
        yield return new WaitForSecondsRealtime(2f);

        currScreen++;
        WebManager.main.ChangeURL(screenName + "0" + currScreen);
    }
    public void Previous()
    {

        currScreen--;
        WebManager.main.ChangeURL(screenName + "0" + currScreen);
    }

    public void ChangeScreenName(string _screenName)
    {
        screenName = _screenName;
    }
}

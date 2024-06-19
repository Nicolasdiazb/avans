using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipationTrailManager : Singleton<ParticipationTrailManager>
{
    private string screenName = "participationtrail";
    private int currScreen = 0;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandButton : MonoBehaviour
{
    public List<GameObject> containers;
    public int currIndex;

    public void ShowContainer()
    {
        if (currIndex == 0)
        {
            currIndex = 1;
        }
        else
        {
            currIndex = 0;
        }
        foreach (var item in containers)
        {
            item.SetActive(false);
        }
        containers[currIndex].SetActive(true);
    }
}

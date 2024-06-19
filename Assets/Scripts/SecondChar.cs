using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChar : MonoBehaviour
{
    public List<GameObject> chars;
    public BaseCamp baseCamp;

    public void SetChar()
    {
        foreach (var item in chars)
        {
            item.SetActive(false);
        }
        chars[baseCamp.currID].SetActive(true);
    }
}

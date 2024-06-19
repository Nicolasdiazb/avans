using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDFButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenUrl()
    {
        Application.OpenURL("http://trailtool.org/avans-back.pdf");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateBackPack : MonoBehaviour
{
    public UnityEvent actin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        actin.Invoke();
    }
}

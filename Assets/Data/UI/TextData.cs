using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class TextData
{
    [SerializeField]
    [TextArea]
    public string textString;
    [SerializeField]
    public float textSize;
    [SerializeField]
    public Color32 textColor;
    [SerializeField]
    public bool isBold;
    [SerializeField]
    public int textID;
}

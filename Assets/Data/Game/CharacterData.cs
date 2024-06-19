using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    [SerializeField]
    public Sprite savedSprite;
    [SerializeField]
    [TextArea]
    public string savedDescription;
    [SerializeField]
    public ButtonImageAndTextData uiSettings;
}

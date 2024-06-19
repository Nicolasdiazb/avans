using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]

public class PopUpBlockData
{
    [SerializeField]
    public List<TextData> texts;
    [SerializeField]
    public List<Sprite> images;
}

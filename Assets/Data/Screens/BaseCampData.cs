using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class BaseCampData 
{

    [SerializeField]
    public Sprite avansLogo;
    [SerializeField]
    public TextData trailMapButtonText;
    [SerializeField]
    public TextData mainText;
    [SerializeField]
    public TextData paragraphText;
    [SerializeField]
    public List<PopUpBlockData> blocks;
    public List<PopUpBlockData> blocks0;
    public List<PopUpBlockData> blocks1;
    public List<PopUpBlockData> blocks2;
    public List<PopUpBlockData> blocks3;
    public List<PopUpBlockData> blocks4;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrailData 
{
    [SerializeField]
    public List<PopUpBlockData> blocks;
    [SerializeField]
    public List<PopUpBlockData> Button1NestedBlocks;
    [SerializeField]
    public List<PopUpBlockData> Button2NestedBlocks;
    [SerializeField]
    public List<PopUpBlockData> Button3NestedBlocks;
}

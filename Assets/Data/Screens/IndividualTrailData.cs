using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class IndividualTrailData
{
    [Header("PopUp")]
    [SerializeField]
    public List<PopUpBlockData> blocks;
    [SerializeField]
    public List<IndividualTrailScreen> charactersData;
}

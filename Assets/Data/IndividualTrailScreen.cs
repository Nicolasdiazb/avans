using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IndividualTrailScreen
{
    [SerializeField]
    public enum Character { Student, Teacher, Researhcers, Partners };

    [SerializeField]
    public Character character;
    [SerializeField]
    public List<PopUpBlockData> blocks;
}

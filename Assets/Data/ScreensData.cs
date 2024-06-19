using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenData : ScriptableObject
{
    [SerializeField]
    public HomeData landingPageHome;
    [SerializeField]
    public HomeScreenData homeScreenData;
    [SerializeField]
    public IndividualTrailData individualTrail;
    [SerializeField]
    public BaseCampData baseCamp;
    [SerializeField]
    public DesignTrailData designTrail;
    [SerializeField]
    public LowerCampData lowerCamp;
    [SerializeField]
    public ParticipationTrailData participationTrail;
    [SerializeField]
    public UpperCampData upperCamp;
    [SerializeField]
    public SummitTrailData summitTrail;
    [SerializeField]
    public FinishLineData finishLine;
    [SerializeField]
    public EvaluationTrailData evaluationTrail;
    [SerializeField]
    public RestCampData restCamp;
}

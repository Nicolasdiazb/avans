using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]

public class DesignTrailData 
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
    public List<TrailData> trailsBlock;
}

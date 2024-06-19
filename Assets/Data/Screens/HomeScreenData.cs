using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class HomeScreenData 
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
    public List<CharacterData> charactersButtons;
    [SerializeField]
    public TextData startGameButtonText;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersHandler : MonoBehaviour
{
    public List<GameObject> characters;

    public void SetNewCharacter(int index)
    {
        characters[index].SetActive(true);
    }
    public void Reset()
    {
        foreach (var item in characters)
        {
            item.SetActive(false);
        }
    }
}

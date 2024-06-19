using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseCharacterLogic : MonoBehaviour
{
    public List<GameObject> frames;
    public List<GameObject> menuFrames;
    public List<GameObject> characters;
    public CharactersHandler charHandler;
    public UnityEvent student;
    public UnityEvent teacher;
    public UnityEvent researcher;
    public UnityEvent partner;
    public int currFrame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateFrame(int frameID)
    {
        charHandler.Reset();
        foreach (var item in frames)
        {
            item.SetActive(false);
        }
        foreach (var item in characters)
        {
            item.SetActive(true);
        }
        foreach (var item in menuFrames)
        {
            item.SetActive(false);
        }
        currFrame = frameID;
        characters[frameID].SetActive(false);
        frames[frameID].SetActive(true);
        menuFrames[frameID].SetActive(true);
        charHandler.SetNewCharacter(frameID);
    }
    public void CharacterSelected()
    {
        if (currFrame == 0)
        {
            student.Invoke();
        }
        if (currFrame == 1)
        {

            teacher.Invoke();
        }
        if (currFrame == 2)
        {

            researcher.Invoke();
        }
        if (currFrame == 3)
        {

            partner.Invoke();
        }
    }
}

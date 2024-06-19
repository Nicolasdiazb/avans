using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBackground : MonoBehaviour
{
    public Sprite map;
    public Sprite teacher;
    public Sprite student;
    public Sprite researcher;
    public Sprite partner;
    public Sprite teacher2;
    public Sprite student2;
    public Sprite researcher2;
    public Sprite partner2;
    public GameObject background;

    public void SelectMap()
    {
        GetComponent<SpriteRenderer>().sprite = map;
    }
    public void SelectTeacher()
    {
        GetComponent<SpriteRenderer>().sprite = teacher;
        background.GetComponent<SpriteRenderer>().sprite = teacher2;
    }
    public void SelectStudent()
    {
        GetComponent<SpriteRenderer>().sprite = student;
        background.GetComponent<SpriteRenderer>().sprite = student2;
    }
    public void SelectResearcher()
    {
        GetComponent<SpriteRenderer>().sprite = researcher;
        background.GetComponent<SpriteRenderer>().sprite = researcher2;
    }
    public void SelectPartner()
    {
        GetComponent<SpriteRenderer>().sprite = partner;
        background.GetComponent<SpriteRenderer>().sprite = partner2;
    }
}

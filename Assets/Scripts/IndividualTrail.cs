using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IndividualTrail : MonoBehaviour
{
    public GameObject currPoint;
    public List<GameObject> points;
    public List<GameObject> fire;
    public GameObject characters;
    private int currSprite = -1;
    public UnityEvent finish;
    public GameObject previousButton;

    private void Start()
    {

        previousButton.SetActive(false);
    }
    // Start is called before the first frame update
    public void Next()
    {
        previousButton.SetActive(true);
        gameObject.SetActive(true);
        Debug.LogError("happens");
        currSprite++;
        if (points.Count > currSprite)
        {

        //currPoint.transform.position = points[currSprite].transform.position;
        characters.transform.position = fire[currSprite].transform.position;
        }
        else
        {
            finish.Invoke();
        }
    }

    public void Previous()
    {
        gameObject.SetActive(true);
        Debug.LogError("happens");
        currSprite--;
        if(currSprite<=0)
        {
            previousButton.SetActive(false);
            return;
        }
        previousButton.SetActive(true);
        if (points.Count > currSprite)
        {

            //currPoint.transform.position = points[currSprite].transform.position;
            characters.transform.position = fire[currSprite].transform.position;
        }
        else
        {
            finish.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

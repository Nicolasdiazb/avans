using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    public GameObject point;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(1))
        {

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(0, 0, pos.y * dragSpeed);

            point.transform.Translate(move, Space.World);
            point.transform.Translate(move, Space.World);
        }
        else if (Input.GetMouseButton(0))
        {

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            point.transform.Translate(move, Space.World);
            point.transform.Translate(move, Space.World);
        }

    }


}
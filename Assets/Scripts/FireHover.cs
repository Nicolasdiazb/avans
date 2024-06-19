using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHover : MonoBehaviour
{
    public int index;
    public DesignTrail design;
    void OnMouseOver()
    {
        design.ShowModal(index, transform.position);
        if (Input.GetMouseButtonUp(0))
            design.SelectModal(index);
    }

    void OnMouseExit()
    {
        design.HideModal();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColors : MonoBehaviour
{
    public List<Image> buttons;
    public Color32 disabledColor;
    public Color32 enabledColor;

    // Start is called before the first frame update
    public void ActivateButton(int id)
    {
        foreach (var item in buttons)
        {
            item.color = disabledColor;
        }
        buttons[id].color = enabledColor;
    }
}

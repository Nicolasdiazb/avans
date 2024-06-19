using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestComponent : MonoBehaviour
{
    public ScreenData data;
    public Transform container;
    public GameObject poUpBlockPrefab;
    public GameObject textPrefab;
    public GameObject imagePrefab;
    public GameObject buttonsPrefab;

    public void ShowTab(int id)
    {

        foreach (Transform child in container.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        List<PopUpBlockData> tempBloc = new List<PopUpBlockData>();
        if (id == 0)
        {
            tempBloc = data.baseCamp.blocks0;
        }
        if (id == 1)
        {
            tempBloc = data.baseCamp.blocks1;
        }
        if (id == 2)
        {
            tempBloc = data.baseCamp.blocks2;
        }
        if (id == 3)
        {
            tempBloc = data.baseCamp.blocks3;
        }
        if (id == 4)
        {
            tempBloc = data.baseCamp.blocks4;
        }
        foreach (var item in tempBloc)
        {
            GameObject tempBlock = Instantiate(poUpBlockPrefab, container);
            foreach (var item2 in item.texts)
            {
                GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                if(item2.isBold)
                    tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            }
            foreach (var item2 in item.images)
            {
                GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                tempText.GetComponent<Image>().sprite = item2;
                tempText.GetComponent<Image>().preserveAspect = true;
            }

        }

        GameObject tempButtons = Instantiate(buttonsPrefab, container);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterTrail : MonoBehaviour
{
    private int currSprite = 0;
    public List<Sprite> containers;
    public List<TextMeshProUGUI> texts;
    public List<Toggle> toggles;
    public Image img;
    public Color32 textDisabledColor;
    public Color32 textEnabledColor;
    public Color32 circleDisabledColor;
    public Color32 circleEnabledColor;
    public GameObject nextScreen;
    public List<GameObject> individualChars;
    public GameObject previousButton;
    public GameObject buttonReStart;
    void Start()
    {
        buttonReStart.SetActive(true);
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    public void Next()
    {
        if (currSprite < containers.Count - 1)
        {
            previousButton.SetActive(true);
            foreach (var item in individualChars)
            {
                if (item.gameObject.activeSelf)
                {
                    item.GetComponent<IndividualTrail>().Next();
                }
            }
            currSprite++;
            img.sprite = containers[currSprite];
            foreach (var item in texts)
            {
                item.color = textDisabledColor;
            }
            texts[currSprite].color = textEnabledColor;
            foreach (var item in toggles)
            {
                var newColorBlock = item.colors;
                newColorBlock.disabledColor = circleDisabledColor;
                item.colors = newColorBlock;
            }
            var newColorBlock2 = toggles[currSprite].colors;
            newColorBlock2.disabledColor = circleEnabledColor;
            toggles[currSprite].colors = newColorBlock2;
            texts[currSprite].color = textEnabledColor;
        }
        else
        {
            nextScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void Previous()
    {
        if (currSprite > 0)
        {
            if (currSprite <= 0)
            {
                previousButton.SetActive(false);
                return;
            }
            foreach (var item in individualChars)
            {
                if (item.gameObject.activeSelf)
                {
                    item.GetComponent<IndividualTrail>().Previous();
                }
            }
            currSprite--;
            img.sprite = containers[currSprite];
            foreach (var item in texts)
            {
                item.color = textDisabledColor;
            }
            texts[currSprite].color = textEnabledColor;
            foreach (var item in toggles)
            {
                var newColorBlock = item.colors;
                newColorBlock.disabledColor = circleDisabledColor;
                item.colors = newColorBlock;
            }
            var newColorBlock2 = toggles[currSprite].colors;
            newColorBlock2.disabledColor = circleEnabledColor;
            toggles[currSprite].colors = newColorBlock2;
            texts[currSprite].color = textEnabledColor;
        }
    }
}

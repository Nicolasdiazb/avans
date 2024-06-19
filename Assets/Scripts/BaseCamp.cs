using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class BaseCamp : MonoBehaviour
{
    private int currSprite = 0;
    public List<Sprite> containers;
    public List<Sprite> characters;
    public List<TextMeshProUGUI> texts;
    public List<Toggle> toggles;
    public Image img;
    public Color32 textDisabledColor;
    public Color32 textEnabledColor;
    public Color32 circleDisabledColor;
    public Color32 circleEnabledColor;
    public int currID = 0;
    public Image selectedCharacter;
    public UnityEvent characterPhase;
    public List<Sprite> tabsStates;
    public List<Button> tabs;
    public GameObject tabsContainer;
    public GameObject prebContainer;
    public GameObject buttonOnChooseScreen;
    public int currTrailDecition = 0;
    public List<GameObject> trails;
    public CharactersHandler chars;
    public Button backButton;
    public Button nextButton;
    public GameObject modal;
    public Button NextButton;
    public Button PreviousButton;
    public UnityEvent participationEvent;
    public UnityEvent participationEventPrevious;

    private void OnEnable()
    {
        if (modal != null)
            modal.SetActive(false);
    }

    private void OnDisable()
    {

        if (modal != null)
        {
            modal.SetActive(true);
            participationEvent.Invoke();
            NextButton.onClick.AddListener(() =>
            {
                participationEvent.Invoke();
            });
            PreviousButton.onClick.AddListener(() =>
            {
                participationEventPrevious.Invoke();
            });
        }
    }

    public void SetTrailDecition(int trail)
    {
        currTrailDecition = trail;
    }

    // Update is called once per frame
    public void Next()
    {
        if (currSprite < containers.Count - 1)
        {
            backButton.gameObject.SetActive(true);
            if (currSprite == 0)
            {
                currSprite++;
                characterPhase.Invoke();
                selectedCharacter.sprite = characters[currID];
                chars.SetNewCharacter(currID);
            }
            else
            {
                if (currSprite == 2)
                {
                    currSprite++;
                    prebContainer.SetActive(false);
                    tabsContainer.SetActive(true);
                    SelectTab(0);
                }
                else
                {
                    if (currSprite == 3)
                    {
                        currSprite++;
                        prebContainer.SetActive(true);
                        tabsContainer.SetActive(false);
                    }
                    else
                    {
                        currSprite++;
                    }
                    if (currSprite == 4)
                    {
                        buttonOnChooseScreen.SetActive(true);
                    }
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
        else
        {
            foreach (var item in trails)
            {
                item.SetActive(false);
            }
            trails[currTrailDecition].SetActive(true);
        }

    }
    public void CancelCharacter()
    {
        currSprite = 0;
    }
    public void Previous()
    {
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(Previous);
        if (currSprite <= 0)
        {
            backButton.gameObject.SetActive(false);
            return;
        }
        if (currSprite > 0)
        {
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

    public void SelectCharacter(int id)
    {
        currID = id;
    }

    public void SelectTab(int id)
    {
        GetComponent<TestComponent>().ShowTab(id);
        foreach (var item in tabs)
        {
            item.GetComponent<Image>().sprite = tabsStates[0];
            item.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
        tabs[id].GetComponent<Image>().sprite = tabsStates[1];
        tabs[id].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }
}

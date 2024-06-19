using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class DesignTrail : MonoBehaviour
{

    public ScreenData data;
    public Transform container;
    public Transform container2;
    public GameObject nestedModal;
    public GameObject poUpBlockPrefab;
    public GameObject textPrefab;
    public GameObject imagePrefab;
    public GameObject expandButton;
    public GameObject characters;


    public List<Toggle> toggles;
    public List<TextMeshProUGUI> texts;

    private int currSprite = -1;
    public Color32 textDisabledColor;
    public Color32 textEnabledColor;
    public Color32 circleDisabledColor;
    public Color32 circleEnabledColor;
    public GameObject nextScreen;
    public List<GameObject> objsToDeactivate;
    public GameObject currPoint;
    public List<GameObject> points;
    public List<GameObject> fire;
    public GameObject buttonsPrefab;
    private int maxSprite = 8;
    private bool ended = false;
    public UnityEvent finished;
    public GameObject previousButton;
    public GameObject modal;
    public TextMeshProUGUI modalText;
    private Camera cam;
    public GameObject initialPos;
    public bool init = false;
    public GameObject scrollview;
    public Image textureImage;
    GameObject tempButtons;
    public GameObject charactersHolder;
    void Start()
    {
        StartCoroutine(GetText());
        if (charactersHolder!=null)
        {
            charactersHolder.SetActive(true);
        }
        cam = Camera.main;
        foreach (var item in objsToDeactivate)
        {
            item.SetActive(false);
        }
        if (init)
        {
            currPoint.transform.position = initialPos.transform.position;
        }
        else
        {
            Next();
        }
    }
    public void ShowModal(int index,Vector3 point)
    {
        scrollview.SetActive(true);
        modal.transform.position = Camera.main.WorldToScreenPoint(point);
        modal.SetActive(true);
        modalText.text = data.designTrail.trailsBlock[index].blocks[1].texts[0].textString;
    }

    IEnumerator GetText()
    {
        for (int i = 1; i < 7; i++)
        {
            string url = "https://trailtool.org/Admin/pages/forms/examples/gettitle.php?sname=designtrail0" + i;
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.Send();

            if (www.isError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                // Show results as text
                //results1 = 0x01;
                Debug.LogError(www.downloadHandler.text);
                string trimstring = "<h1 style=\"margin - bottom: 16px; font - family: Roboto, sans - serif; font - weight: 700; line - height: 1.4; color: rgb(51, 51, 51); font - size: 32px; \" > ";
                data.designTrail.trailsBlock[i].blocks[1].texts[0].textString = Regex.Replace(www.downloadHandler.text, "<.*?>", System.String.Empty);
            }
        }
        
    }
    public void SelectModal(int index)
    {
        currSprite = index - 1;
        Next();
    }
    public void HideModal()
    {
        modal.SetActive(false);
    }



    // Update is called once per frame
    public void Next()
    {

        if (currSprite < maxSprite-1)
        {
            previousButton.SetActive(true);
            if (currSprite < 0)
            {
                previousButton.SetActive(false);
            }
            currSprite++;
            currPoint.transform.position = points[currSprite].transform.position;
            characters.transform.position = fire[currSprite].transform.position;
            fire[currSprite].SetActive(true);
            foreach (Transform child in container.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            List<PopUpBlockData> tempBloc = new List<PopUpBlockData>();
            if(currSprite >= 12)
            {
                finished.Invoke();
                return;
            }
            tempBloc = data.designTrail.trailsBlock[currSprite].blocks;
            foreach (var item in tempBloc)
            {
                GameObject tempBlock = Instantiate(poUpBlockPrefab, container);
                foreach (var item2 in item.texts)
                {
                    GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                    tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                    tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                    tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                    if (item2.isBold)
                        tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                }
                foreach (var item2 in item.images)
                {
                    GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                    tempText.GetComponent<Image>().sprite = item2;
                    tempText.GetComponent<Image>().preserveAspect = true;
                }

            }
            foreach (var item in texts)
            {
                item.color = textDisabledColor;
            }
            var currSprite2 = currSprite;
            if (ended)
            {
                currSprite2 = currSprite2 - 8;
            }
            if (texts.Count > currSprite2)
            {

            texts[currSprite2].color = textEnabledColor;
            texts[currSprite2].color = textEnabledColor;
            }
            foreach (var item in toggles)
            {
                var newColorBlock = item.colors;
                newColorBlock.disabledColor = circleDisabledColor;
                item.colors = newColorBlock;
            }
            if (toggles.Count > currSprite2)
            {

                var newColorBlock2 = toggles[currSprite2].colors;
                newColorBlock2.disabledColor = circleEnabledColor;
                toggles[currSprite2].colors = newColorBlock2;
            }
            tempButtons = Instantiate(buttonsPrefab, container);
            List<Button> buttons = tempButtons.GetComponentsInChildren<Button>().ToList();
            foreach (var item in buttons)
            {
                item.onClick.RemoveAllListeners();
            }
            buttons[0].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                Debug.LogError("Happening "+ currSprite);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button1NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        //tempText.GetComponent<TextMeshProUGUI>().text = button1;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });
            buttons[1].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button2NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        //tempText.GetComponent<TextMeshProUGUI>().text = button2;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });
            buttons[2].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button3NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        //tempText.GetComponent<TextMeshProUGUI>().text = button3;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });

        }
        else
        {
            ended = true;
            maxSprite = 14;
            nextScreen.SetActive(true);
        }
    }
    public void Previous()
    {

        if (currSprite > 0)
        {
            currSprite--;
            if (currSprite <= 0)
            {
                previousButton.SetActive(false);
            }
            currPoint.transform.position = points[currSprite].transform.position;
            characters.transform.position = fire[currSprite].transform.position;
            fire[currSprite].SetActive(true);
            foreach (Transform child in container.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            List<PopUpBlockData> tempBloc = new List<PopUpBlockData>();
            tempBloc = data.designTrail.trailsBlock[currSprite].blocks;
            foreach (var item in tempBloc)
            {
                GameObject tempBlock = Instantiate(poUpBlockPrefab, container);
                foreach (var item2 in item.texts)
                {
                    GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                    tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                    tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                    tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                    if (item2.isBold)
                        tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                }
                foreach (var item2 in item.images)
                {
                    GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                    tempText.GetComponent<Image>().sprite = item2;
                    tempText.GetComponent<Image>().preserveAspect = true;
                }

            }
            foreach (var item in texts)
            {
                item.color = textDisabledColor;
            }
            var currSprite2 = currSprite;
            if (ended)
            {
                currSprite2 = currSprite2 - 8;
            }
            texts[currSprite2].color = textEnabledColor;
            foreach (var item in toggles)
            {
                var newColorBlock = item.colors;
                newColorBlock.disabledColor = circleDisabledColor;
                item.colors = newColorBlock;
            }
            var newColorBlock2 = toggles[currSprite2].colors;
            newColorBlock2.disabledColor = circleEnabledColor;
            toggles[currSprite2].colors = newColorBlock2;
            texts[currSprite2].color = textEnabledColor;
            GameObject tempButtons = Instantiate(buttonsPrefab, container);
            List<Button> buttons = tempButtons.GetComponentsInChildren<Button>().ToList();
            foreach (var item in buttons)
            {
                item.onClick.RemoveAllListeners();
            }
            buttons[0].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                Debug.LogError("Happening " + currSprite);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button1NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });
            buttons[1].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button2NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });
            buttons[2].onClick.AddListener(() =>
            {
                foreach (Transform child in container2.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                expandButton.SetActive(false);
                nestedModal.gameObject.SetActive(true);
                List<PopUpBlockData> tempBloc2 = new List<PopUpBlockData>();
                tempBloc2 = data.designTrail.trailsBlock[currSprite].Button3NestedBlocks;
                foreach (var item in tempBloc2)
                {
                    GameObject tempBlock = Instantiate(poUpBlockPrefab, container2);
                    foreach (var item2 in item.texts)
                    {
                        GameObject tempText = Instantiate(textPrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<RectTransform>().sizeDelta = new Vector2(246.89f, 0);
                        tempText.GetComponent<TextMeshProUGUI>().text = item2.textString;
                        tempText.GetComponent<TextMeshProUGUI>().fontSize = item2.textSize;
                        if (item2.isBold)
                            tempText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    foreach (var item2 in item.images)
                    {
                        GameObject tempText = Instantiate(imagePrefab, tempBlock.GetComponent<PopUpBlock>().container);
                        tempText.GetComponent<Image>().sprite = item2;
                        tempText.GetComponent<Image>().preserveAspect = true;
                    }

                }
            });

        }
    }
}

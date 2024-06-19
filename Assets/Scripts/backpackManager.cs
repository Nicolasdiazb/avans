using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class backpackManager : MonoBehaviour
{
    public List<BackPackiTEM> currItems;
    public GameObject holder;
    public GameObject itemPrefab;
    public List<GameObject> currObjs;
    public int currSlide=0;
    public List<string> titles;
    public List<string> titles2;
    public List<GameObject> objsToActivate;
    public Sprite itemOn;
    public Sprite itemOff;
    public List<Image> itemButtons;
    public List<GameObject> modals;


    private int lastID = 0;
    private int currID = 0;

    public void ChangeSlide(bool forward)
    {
        if (forward)
            currID++;
        else
            currID--;

        List<BackPackiTEM> matchedData = currItems.Where(ci => ci.id == currID).ToList();
        if (matchedData.Count > 0)
        {
            foreach (var item in itemButtons)
            {
                item.sprite = itemOn;
            }
        }
        else
        {
            foreach (var item in itemButtons)
            {
                item.sprite = itemOff;
            }
        }
    }

    public void InteractWithPDF()
    {
        List<BackPackiTEM> matchedData = currItems.Where(ci => ci.id == currID).ToList();
        if (matchedData.Count > 0)
        {
            DeleteItem(matchedData[0].id, matchedData[0].title);
        }
        else
        {
            AddItem();
        }
    }

    public void AddItem()
    {
        BackPackiTEM tempItem = new BackPackiTEM();
        tempItem.title = titles2[currID];
        tempItem.id = currID;
        List<BackPackiTEM> matchedData = currItems.Where(ci => ci.id == currID).ToList();
        if(matchedData.Count<=0)
            currItems.Add(tempItem);
        foreach (var item in itemButtons)
        {
            item.sprite = itemOn;
        }
    }

    public void ShowBackPack()
    {
        foreach (var item in modals)
        {
            item.SetActive(false);
        }
        foreach (var item in objsToActivate)
        {
            item.SetActive(true);
        }
        foreach (Transform child in holder.transform)
        {
            Destroy(child.gameObject);
        }
        holder.SetActive(false);
        gameObject.SetActive(true);
        if(currItems.Count > 0)
        {
            holder.SetActive(true);
            foreach (var item in currItems)
            {
                GameObject tempItem = Instantiate(itemPrefab, holder.transform);
                tempItem.GetComponentInChildren<TextMeshProUGUI>().text = item.title;
                tempItem.GetComponentInChildren<Button>().onClick.AddListener(() => {
                    DeleteItem(item.id, item.title);
                    }); 
            }
        }
        else
        {
        }
    }

    public void DeleteItem(int id, string title)
    {
        List<GameObject> tempItems = currObjs.Where(c => c.GetComponentInChildren<TextMeshProUGUI>().text.Equals(title)).ToList();
        currItems = currItems.Where(c => c.id != id).ToList();
        if (tempItems.Count > 0)
        {
            Destroy(tempItems[0].gameObject);
        }
        List<BackPackiTEM> matchedData = currItems.Where(ci => ci.id == currID).ToList();
        if (matchedData.Count > 0)
        {
            foreach (var item in itemButtons)
            {
                item.sprite = itemOn;
            }
        }
        else
        {
            foreach (var item in itemButtons)
            {
                item.sprite = itemOff;
            }
        }
        ShowBackPack();
    }

    public void OpenPDF()
    {
        foreach (var item in currItems)
        {
            string url = "http://trailtool.org/" + item.id + ".pdf";
            Application.OpenURL(url);
        }
    }
    public void HideBackPack()
    {
        foreach (var item in objsToActivate)
        {
            item.SetActive(false);
        }
    }
}

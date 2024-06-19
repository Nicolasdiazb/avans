using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuplex.WebView;

public class WebManager : Singleton<WebManager>
{
    public List<CanvasWebViewPrefab> canvasWebViewPrefabs;
    private int currWebView = 1;

    public void ChangeURL(string screenName)
    {
        foreach (var item in canvasWebViewPrefabs)
        {
            if (item.WebView != null)
            {
                item.WebView.LoadUrl("https://trailtool.org/Admin/pages/forms/examples/firstscreen.php?sname="+screenName);
            }
        }
    }

    public bool AlreadyInit()
    {
        return canvasWebViewPrefabs[2].initialized;
    }

    public void ExpandInteraction()
    {
        canvasWebViewPrefabs[1].gameObject.SetActive(true);
        canvasWebViewPrefabs[0].gameObject.SetActive(false);
        canvasWebViewPrefabs[3].gameObject.SetActive(true);
        canvasWebViewPrefabs[2].gameObject.SetActive(false);
    }
}

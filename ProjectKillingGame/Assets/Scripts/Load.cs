using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    private static Load instance = null;
    private List<List<GameObject>> savefiles;
    public GameObject viewport;

    public static Load Instance
    {
        get { return instance; }
    }
    
    private void Awake()
    {
        GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
        GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
        GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    public void openLoadMenu()
    {
        if (GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, 450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = true;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = true;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(1f);
        } else {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
            //TODO: Exchange for draggable Menu with different Translation
        }

        if (savefiles != null)
        {
            loadData();
        }
    }

    public void loadData()
    {
        
    }

    public List<List<GameObject>> getSaveFiles(List<GameObject> b)
    {
        savefiles.Add(b);
        return savefiles;
    }

    public List<List<GameObject>> getSaveFiles()
    {
        return savefiles;
    }

    public int getCount()
    {
        return savefiles.Count;
    }
}

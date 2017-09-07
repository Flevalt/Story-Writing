using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    public SaveFile savefile;
    public Save save;
    private static Load instance = null;
    private List<GameObject> savefiles;
    public GameObject viewport;

    public Sprite savefilesprite;
    private Vector2 vect = new Vector2(100f, 100f);
    public GameObject content;

    public static Load Instance
    {
        get { return instance; }
    }
    
    private void Awake()
    {
        savefiles = new List<GameObject>();

        int c = 1; //loopcount
        int lastC = 0; //last element in the list
        for (int i = 0; i < c; i++)
        {
            if (float.IsNaN(PlayerPrefs.GetFloat("textspeed" + c)))
            {
                c += 1;
            }
            else { lastC = c - 1; }
        }
        for (int j=1; j<lastC+1; j++)
        {
            savefile.setAll(j);
            savefiles.Add(savefile.getSaveFile());
        }

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

            int c = 1; //loopcount
            int lastC = 0; //last element in the list
            for (int i = 0; i < c; i++)
            {
                if (float.IsNaN(PlayerPrefs.GetFloat("textspeed" + c)))
                {
                    lastC = c;
                    c += 1;
                }
            }

                for (int i = 0; i < lastC; i++)
                {
                    save.createButtonForSave(savefilesprite, vect, content, lastC);
                }

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

    public List<GameObject> getSaveFiles()
    {
        return savefiles;
    }

    public int getCount()
    {
        return savefiles.Count;
    }
}

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
            if (PlayerPrefs.HasKey("textspeed" + c))
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
                if (PlayerPrefs.HasKey("textspeed" + c))
                {
                    lastC = c;
                    c += 1;
                }
            }

            for (int i = 0; i < lastC; i++)
            {
                int k = i + 1;
                if (GameObject.Find("SaveFileBG(Clone)" + k) == null) {
                    Button btn = save.createButtonForSave(savefilesprite, vect, content, k);
                    btn.GetComponent<SaveFile>().savefileindex = k;
                }
            }

        } else {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
    }

    //TODO: Load savedata dynamically depending on index instead of constant 1
    public void loadData(int savefileIndex)
    {

        //load textspeed (finished)
        GameObject.Find("Textbox").GetComponent<TextWrite>().setF(PlayerPrefs.GetFloat("textspeed" + savefileIndex));

        //load BG (To be extended by more BGs)
        switch (PlayerPrefs.GetInt("currentBG" + savefileIndex)){
            case 1:
                GameObject.Find("MainCam").GetComponent<Transform>().position = new Vector3(0f, 0f, -10f);
                break;
            case 2:
                GameObject.Find("MainCam").GetComponent<Transform>().position = new Vector3(-24f, 0f, -10f);
                break;
        }

        //load Char1 and Char2 (finished)
        GameObject.Find("Char1").GetComponent<Image>().sprite = GameObject.Find("SpriteCon").GetComponent<SpriteCon>().loadAvatar(PlayerPrefs.GetInt("Char1" + savefileIndex));
        GameObject.Find("Char2").GetComponent<Image>().sprite = GameObject.Find("SpriteCon").GetComponent<SpriteCon>().loadAvatar(PlayerPrefs.GetInt("Char2" + savefileIndex));
        GameObject.Find("Controller").GetComponent<Controller>().charDisplay(PlayerPrefs.GetInt("CharOn" + savefileIndex));

        //load current Chapter
        GameObject.Find("NovelStorage").GetComponent<Novel>().savedIndex = PlayerPrefs.GetInt("currentIndex" + savefileIndex);
        //load current Paragraph
        GameObject.Find("NovelStorage").GetComponent<Novel>().setCurrentLine(PlayerPrefs.GetInt("currentLine" + savefileIndex));
        GameObject.Find("Textbox").GetComponent<Text>().text = GameObject.Find("NovelStorage").GetComponent<Novel>().getCurrentCh(PlayerPrefs.GetInt("currentIndex" + savefileIndex))[PlayerPrefs.GetInt("currentLine" + savefileIndex)];
        GameObject.Find("Textbox").GetComponent<TextWrite>().setLoaded(true);
    }

    public List<GameObject> getSaveFiles()
    {
        return savefiles;
    }

    public int getCount()
    {
        return savefiles.Count;
    }

    public void deleteAll()
    {
        //delete persistent savedata
        PlayerPrefs.DeleteAll();
        //Destroy visual savefile buttons
        //delete temporary savefile list and compress Content-Scrollbar
        int c = getSaveFiles().Count;
        int loops = 0;
        for(int i=0; i<c; c--)
        {
            int k = loops + 1;
            Destroy(GameObject.Find("SaveFileBG(Clone)" + k));
            Destroy(GameObject.Find("Savefile(Clone)" + k));
            Destroy(GameObject.Find("DeleteBtn(Clone)" + k));
            GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta = GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta + new Vector2(0f, -150f);
            getSaveFiles().RemoveAt(i);
            loops += 1;
        }
    }

    public int lastDeletedElem()
    {
        for (int z = 0; z < getSaveFiles().Count; z++)
        {
            int cnt = z + 1;
            Debug.Log("cnt" + PlayerPrefs.GetFloat("textspeed" + cnt));
            if (PlayerPrefs.GetFloat("textspeed" + cnt) == 0f)
            {
                return cnt;
            }
        }
        return 0;
    }

    public void sortPlayerPrefs()
    {
        for (int i = lastDeletedElem(); i < getSaveFiles().Count+1; i++)
        {
            int z = i + 1;

            PlayerPrefs.SetFloat("textspeed" + i, PlayerPrefs.GetFloat("textspeed" + z)); //overwrite n with n+1
            PlayerPrefs.SetInt("currentBG" + i, PlayerPrefs.GetInt("currentBG" + z));
            PlayerPrefs.SetInt("Char1" + i, PlayerPrefs.GetInt("Char1" + z));
            PlayerPrefs.SetInt("Char2" + i, PlayerPrefs.GetInt("Char2" + z));
            PlayerPrefs.SetInt("CharOn" + i, PlayerPrefs.GetInt("CharOn" + z));
            PlayerPrefs.SetInt("currentIndex" + i, PlayerPrefs.GetInt("currentIndex" + z));
            PlayerPrefs.SetInt("currentLine" + i, PlayerPrefs.GetInt("currentLine" + z));

            PlayerPrefs.DeleteKey("textspeed" + z); // delete n+1
            PlayerPrefs.DeleteKey("currentBG" + z);
            PlayerPrefs.DeleteKey("Char1" + z);
            PlayerPrefs.DeleteKey("Char2" + z);
            PlayerPrefs.DeleteKey("CharOn" + z);
            PlayerPrefs.DeleteKey("currentIndex" + z);
            PlayerPrefs.DeleteKey("currentLine" + z);
        }
    }

}

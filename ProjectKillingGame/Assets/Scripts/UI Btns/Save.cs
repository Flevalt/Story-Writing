using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {

    public Load loadMenu;
    public Novel novel;
    public Controller control;
    public TextWrite textwr;

    public Sprite otherBG;
    public Sprite deleteBtn;
    public Sprite savefilesprite;
    private Vector2 vect = new Vector2(100f, 100f);
    public GameObject singlesave;
    public GameObject content;

    private int SFcount = 0; //count of savefiles
    private int spritenr; // id of savefile img
    private Time creationTime; //time savefile was created

    GameObject btnBG;
    GameObject Btn;
    GameObject delBtn;
    public bool firstbuttoncreated = false;

    public UIManager UIManager;

    private void Awake()
    {
        btnBG = new GameObject("SaveFileBG");
        Btn = new GameObject("Savefile");
        delBtn = new GameObject("DeleteBtn");
    }

    public Button createButtonForSave(Sprite sprite, Vector2 size, GameObject canvas, int c)
    {

        GameObject BGInst = Instantiate(btnBG);
        GameObject BtnInst = Instantiate(Btn);
        GameObject delInst = Instantiate(delBtn);

        //Add savefile index
        BtnInst.AddComponent<SaveFile>();
        Image BGimg = BGInst.AddComponent<Image>();
        Image saveImg = BtnInst.AddComponent<Image>();
        BGimg.sprite = otherBG;
        BGimg.rectTransform.sizeDelta = new Vector2(380f, 150f);
        BGInst.transform.SetParent(canvas.transform, false);

        BtnInst.GetComponent<SaveFile>().savefileindex = c;
        BGInst.name = "SaveFileBG(Clone)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance
        BtnInst.name = "Savefile(Clone)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance
        delInst.name = "DeleteBtn(Clone)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance

        BGInst.AddComponent<Button>().onClick.AddListener(() => { UIManager.confirmationWindow(); control.setSelectedSave(BtnInst.GetComponent<SaveFile>().savefileindex); });

        // change position of BG within content area
        BGimg.rectTransform.position = BGimg.rectTransform.position + new Vector3(-10f, 150f - 150 * c, 0f);
        //Create Savefile Button
        saveImg.sprite = sprite;
        saveImg.rectTransform.sizeDelta = size;

        Button button = BtnInst.AddComponent<Button>();
        BtnInst.transform.SetParent(BGInst.transform, false); //attach to btnBG
        BtnInst.GetComponent<Button>().onClick.AddListener(() => { UIManager.confirmationWindow(); control.setSelectedSave(BtnInst.GetComponent<SaveFile>().savefileindex); });

        saveImg.rectTransform.position = saveImg.rectTransform.position + new Vector3(-120f, 0f, 0f);

        // expand the Content area
        GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta = GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta + new Vector2(0f, 150f);
        firstbuttoncreated = true;

        Image delete = delInst.AddComponent<Image>();
        delete.sprite = deleteBtn;
        delete.rectTransform.sizeDelta = new Vector2(160f, 30f);

        Button button1 = delInst.AddComponent<Button>();
        delInst.transform.SetParent(BGInst.transform, false); //attach to btnBG

        delete.rectTransform.position = saveImg.rectTransform.position + new Vector3(220f, -40f, 0f);
        delInst.GetComponent<Button>().onClick.AddListener(() => {
            GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta = GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta + new Vector2(0f, -150f);
            Destroy(BtnInst);
            Destroy(BGInst);
            Destroy(delInst);
            deleteData(BtnInst.GetComponent<SaveFile>().savefileindex);
            Debug.Log("1:" + PlayerPrefs.GetFloat("textspeed1"));
            Debug.Log("2:" + PlayerPrefs.GetFloat("textspeed2"));
            Debug.Log("3:" + PlayerPrefs.GetFloat("textspeed3"));
            Debug.Log("4:" + PlayerPrefs.GetFloat("textspeed4"));
            Debug.Log("5:" + PlayerPrefs.GetFloat("textspeed5"));
            Debug.Log("6:" + PlayerPrefs.GetFloat("textspeed6"));
            //loadMenu.getSaveFiles().RemoveAt(BtnInst.GetComponent<SaveFile>().savefileindex);
            //loadMenu.sortPlayerPrefs();
            Debug.Log("1:" + PlayerPrefs.GetFloat("textspeed1"));
            Debug.Log("2:" + PlayerPrefs.GetFloat("textspeed2"));
            Debug.Log("3:" + PlayerPrefs.GetFloat("textspeed3"));
            Debug.Log("4:" + PlayerPrefs.GetFloat("textspeed4"));
            Debug.Log("5:" + PlayerPrefs.GetFloat("textspeed5"));
            Debug.Log("6:" + PlayerPrefs.GetFloat("textspeed6"));
            for (int j = BtnInst.GetComponent<SaveFile>().savefileindex; j < loadMenu.getCount() + 1; j++)
            {
                    int y = j + 1;
                    int x = y - 1;
                    Debug.Log("y" + y);
                    GameObject.Find("SaveFileBG(Clone)" + y).name = "SaveFileBG(Clone)" + x;
                    GameObject.Find("Savefile(Clone)" + y).name = "Savefile(Clone)" + x;
                    GameObject.Find("DeleteBtn(Clone)" + y).name = "DeleteBtn(Clone)" + x;
            }
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        });

        return button;
    }

    public void deleteData(int i)
    {
        PlayerPrefs.DeleteKey("textspeed" + i);
        PlayerPrefs.DeleteKey("currentBG" + i);
        PlayerPrefs.DeleteKey("Char1" + i);
        PlayerPrefs.DeleteKey("Char2" + i);
        PlayerPrefs.DeleteKey("CharOn" + i);
        PlayerPrefs.DeleteKey("currentIndex" + i);
        PlayerPrefs.DeleteKey("currentLine" + i);
        PlayerPrefs.Save();
    }

    public void saveData()
    {
        if (GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().GetAlpha() == 1f)
        {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        }

        int loopcount = 1;
        for (int i = 0;i<loopcount; i++)
        {
            if (PlayerPrefs.HasKey("textspeed" + 1*loopcount))
            {
                loopcount += 1;
            } else {
                PlayerPrefs.SetFloat("textspeed" + 1*loopcount, textwr.getF());
                PlayerPrefs.SetInt("currentBG" + 1 * loopcount, control.currentBG);
                PlayerPrefs.SetInt("Char1" + 1 * loopcount, control.getChar1());
                PlayerPrefs.SetInt("Char2" + 1 * loopcount, control.getChar2());
                PlayerPrefs.SetInt("CharOn" + 1 * loopcount, control.getCharOn());
                PlayerPrefs.SetInt("currentIndex" + 1 * loopcount, novel.savedIndex);
                PlayerPrefs.SetInt("currentLine" + 1 * loopcount, novel.getCurrentLine());
                PlayerPrefs.Save();
                singlesave.GetComponent<SaveFile>().setAll(loopcount);
                loopcount = 1;
            }
        }

        //loadMenu.getSaveFiles().Add(singlesave); //Add savefile to list of savefiles

        int count = loadMenu.getCount();
        Button btn = createButtonForSave(savefilesprite, vect, content, count);
        btn.GetComponent<SaveFile>().savefileindex = count;
    }
}

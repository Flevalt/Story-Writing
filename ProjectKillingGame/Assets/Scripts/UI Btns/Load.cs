using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    //extern objects
    public SaveFile savefile;
    public Sprite savefilesprite;
    public GameObject content;
    public Inspection inspection;
    public Sprite Noch;
    public Sprite ch1;
    public Sprite ch2;
    public Sprite ch3;
    public Sprite ch4;
    public Sprite ch5;
    public Novel novel;
    public Controller control;
    public TextBox textwr;
    public Sprite otherBG;
    public Sprite deleteBtn;
    public GameObject singlesave;
    public bool firstbuttoncreated = false;
    public Font niggerfont;

    //intern objects
    private Time creationTime; //time savefile was created
    private static Load instance = null;
    private GameObject[] savefiles; //temporary savefiles
    private GameObject btnBG;
    private GameObject Btn;
    private GameObject delBtn;
    private GameObject saveBtn;
    private bool[] listenerAdded; //savefile listeners
    private bool loadingSaves = true;
    private Navigation noneNav = new Navigation();

    public UIManager UIManager;

    public static Load Instance
    {
        get { return instance; }
    }
    
    private void Awake()
    {
        btnBG = new GameObject("SaveFileBG");
        Btn = new GameObject("Savefile");
        delBtn = new GameObject("DeleteBtn");
        saveBtn = new GameObject("SaveBtn");
        listenerAdded = new bool[20];

        for (int i = 1; i < 21; i++)
        {
            if (PlayerPrefs.HasKey("textspeed" + i)) { loadingSaves = true; } else { loadingSaves = false; }
            createButtonForSave(i);
        }

        //instantiate temporary savefile list
        savefiles = new GameObject[20];

        //and fill with old savefiles
        for (int i = 1; i < 21; i++)
        {
            if(PlayerPrefs.HasKey("textspeed" + i))
            savefile.setAll(i);
            savefiles.SetValue(savefile.getSaveFile(), i-1); //Load old savefiles to savefile array
        }

        for (int i = 0; i < 20; i++)
        {
            listenerAdded[i] = false;
        }

        GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
        GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
        GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    public Button createButtonForSave(int c)
    {

        GameObject BGInst = Instantiate(btnBG);
        GameObject BtnInst = Instantiate(Btn);
        GameObject delInst = Instantiate(delBtn);
        GameObject saveInst = Instantiate(saveBtn);

        //Add savefile TEXT
        GameObject txt = new GameObject("txt" + c);
        txt.AddComponent<CanvasRenderer>();
        Text savetxt = txt.AddComponent<Text>();
        txt.transform.SetParent(BGInst.transform, false);

        //Add savefile INDEX
        BtnInst.AddComponent<SaveFile>();
        Image BGimg = BGInst.AddComponent<Image>();
        Image saveImg = BtnInst.AddComponent<Image>();
        BGimg.sprite = otherBG;
        BGimg.rectTransform.sizeDelta = new Vector2(380f, 150f);
        //Create Savefile BUTTON
        saveImg.sprite = savefilesprite;
        saveImg.rectTransform.sizeDelta = new Vector2(100f, 100f);
        BGInst.transform.SetParent(content.transform, false);

        noneNav.mode = Navigation.Mode.None;

        BtnInst.GetComponent<SaveFile>().savefileindex = c;
        BGInst.name = "SaveFileBG(inst)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance
        BtnInst.name = "Savefile(inst)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance
        delInst.name = "DeleteBtn(inst)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance
        saveInst.name = "SaveBtn(inst)" + BtnInst.GetComponent<SaveFile>().savefileindex; //rename each instance

        Button button = BtnInst.AddComponent<Button>();
        BtnInst.transform.SetParent(BGInst.transform, false); //attach to btnBG

        firstbuttoncreated = true;

        Image save = saveInst.AddComponent<Image>();
        Image delete = delInst.AddComponent<Image>();
        delete.sprite = deleteBtn;
        delete.rectTransform.sizeDelta = new Vector2(80f, 30f);
        save.sprite = deleteBtn;
        save.rectTransform.sizeDelta = new Vector2(80f, 30f);

        Button button1 = delInst.AddComponent<Button>();
        Button button2 = saveInst.AddComponent<Button>();
        button1.navigation = noneNav;
        button2.navigation = noneNav;
        button.navigation = noneNav;
        saveInst.transform.SetParent(BGInst.transform, false);
        delInst.transform.SetParent(BGInst.transform, false); //attach to btnBG

        // change position of BG within content area
        if (c == 1)
        {
            BGimg.rectTransform.localPosition = GameObject.Find("Content").GetComponent<RectTransform>().anchoredPosition + new Vector2(0f, 80f);
        }
        else
        {
            BGimg.rectTransform.localPosition = GameObject.Find("SaveFileBG(inst)" + (c - 1)).GetComponent<RectTransform>().localPosition + new Vector3(0f, -150f, 0f);
        }

        saveImg.rectTransform.localPosition = saveImg.rectTransform.localPosition + new Vector3(-120f, 0f, 0f);
        delete.rectTransform.localPosition = saveImg.rectTransform.localPosition + new Vector3(220f, -40f, 0f);
        save.rectTransform.localPosition = saveImg.rectTransform.localPosition + new Vector3(110f, -40f, 0f);

        //Save functionality
        saveInst.GetComponent<Button>().onClick.AddListener(() => {
            PlayerPrefs.SetFloat("textspeed" + c, textwr.getF());
            PlayerPrefs.SetInt("currentBG" + c, control.currentBG);
            PlayerPrefs.SetInt("Char1" + c, control.getChar1());
            PlayerPrefs.SetInt("Char2" + c, control.getChar2());
            PlayerPrefs.SetInt("CharOn" + c, control.getCharOn());
            PlayerPrefs.SetFloat("currentIndex" + c, novel.currentChapter);
            PlayerPrefs.SetInt("currentLine" + c, novel.currentLine);
            PlayerPrefs.SetInt("itemFound1" + c, inspection.itemFound1);
            PlayerPrefs.Save();
            //Set savefile-sprite
            GameObject.Find("Savefile(inst)" + c).GetComponent<Image>().sprite = ch1;
            //Set savefile-text
            GameObject.Find("txt" + c).GetComponent<Text>().font = niggerfont;
            GameObject.Find("txt" + c).GetComponent<Text>().fontSize = 12;
            int nr = PlayerPrefs.GetInt("currentLine" + c) + 1;
            GameObject.Find("txt" + c).GetComponent<Text>().text = "Chapter " + PlayerPrefs.GetInt("currentIndex" + c) + ", Line " + nr;
            //Update savefile list
            singlesave.GetComponent<SaveFile>().setAll(c);
            savefiles.SetValue(singlesave, c - 1); //Add savefile to savefile array

            if (listenerAdded[c - 1] == false) //prevent multiple addition of listeners upon save
            {
                BtnInst.GetComponent<Button>().onClick.AddListener(() => { UIManager.confirmationWindow(); control.setSelectedSave(BtnInst.GetComponent<SaveFile>().savefileindex); });
                listenerAdded[c - 1] = true;
            }
        });

        if (loadingSaves == true)
        {
            if (listenerAdded[c - 1] == false) //prevent multiple additions of the listener
            {
                GameObject.Find("Savefile(inst)" + c).GetComponent<Button>().onClick.AddListener(() => { UIManager.confirmationWindow(); control.setSelectedSave(BtnInst.GetComponent<SaveFile>().savefileindex); });
                listenerAdded[c - 1] = true;
            }
        }

        //Delete functionality
        delInst.GetComponent<Button>().onClick.AddListener(() => {
            //delete from persistent memory
            deleteData(BtnInst.GetComponent<SaveFile>().savefileindex);
            getSaveFiles().SetValue(null, BtnInst.GetComponent<SaveFile>().savefileindex-1); //Delete savefile from savefile array
            //Reset sprites
            BtnInst.GetComponent<Image>().sprite = Noch;
            savetxt.text = "";
            listenerAdded[BtnInst.GetComponent<SaveFile>().savefileindex - 1] = false;
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

    public void openLoadMenu()
    {
        //Show Menu if closed
        if (GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, 1360f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = true;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = true;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(1f);

            for (int i = 1; i < 21; i++)
            {
                if (PlayerPrefs.HasKey("textspeed" + i))
                {
                    //load savefile visuals
                    GameObject.Find("Savefile(inst)" + i).GetComponent<Image>().sprite = ch1;
                    GameObject.Find("txt" + i).GetComponent<Text>().font = niggerfont;
                    GameObject.Find("txt" + i).GetComponent<Text>().fontSize = 12;
                    int nr = PlayerPrefs.GetInt("currentLine" + i) + 1;
                    GameObject.Find("txt" + i).GetComponent<Text>().text = "Chapter " + PlayerPrefs.GetInt("currentIndex" + i) + ", Line " + nr;

                }

            }

        //Close Menu if open
        } else {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -1360f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
    }

    public void loadData(int index)
    {
        //load textspeed (finished)
        GameObject.Find("Textbox").GetComponent<TextBox>().setF(PlayerPrefs.GetFloat("textspeed" + index));

        //load BG (To be extended by more BGs)
        switch (PlayerPrefs.GetInt("currentBG" + index)){
            case 1:
                UIManager.changeBG("SabrinasRoom");
                break;
            case 2:
                UIManager.changeBG("directorAppear1");
                break;
        }

        //load Char1 and Char2 (finished)

        UIManager.switchChar(1,"f001");
        UIManager.switchChar(2,"f003");
        //UIManager.charDisplay(PlayerPrefs.GetInt("CharOn" + index));

        //load current Chapter
        GameObject.Find("NovelStorage").GetComponent<Novel>().currentChapter = PlayerPrefs.GetInt("currentIndex" + index);

        //load current Paragraph
        GameObject.Find("NovelStorage").GetComponent<Novel>().currentLine = PlayerPrefs.GetInt("currentLine" + index);
        GameObject.Find("Textbox").GetComponent<Text>().text = GameObject.Find("NovelStorage").GetComponent<Novel>().getChapter(PlayerPrefs.GetInt("currentIndex" + index))[PlayerPrefs.GetInt("currentLine" + index)];
        GameObject.Find("textwriter(Inst)").GetComponent<TextWrite>().setLoaded(true);

        //close LoadMenu
        GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
        GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
        GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
        GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);

        //exchange inspection element listeners
        //TODO: Only load the objects during entering a room with such objects and NOT during loadData
        inspection.instStoryObject ("1_1_1_door", 220f, -30f, 120f, 320f); //door

        inspection.instDecisionObject ("1_1_1_shaft", -30f, 225f, 80f, 50f, 3, 2, 1); //ventilation shaft
        inspection.instItemFoundObject ("1_1_1_screen", 90f, 60f, 100f, 100f, 2, 0); //screen
        inspection.instItemFoundObject ("1_1_1_sink", 300f, -50f, 80f, 70f, 1, 1); //sink

        inspection.instObject ("1_1_1_toilet", 300f, -200f, 80f, 70f); //toilet
        inspection.instObject ("1_1_1_bed", -220f, -180f, 240f, 120f); //bed
        inspection.instObject ("1_1_1_lights", 150f, 200f, 250f, 70f); //lights
        inspection.instObject ("1_1_1_chair", -20f, -100f, 80f, 90f); //chair

        for (int j = 1; j < savefiles.Length + 1; j++)
            {
                if (PlayerPrefs.GetInt("itemFound" + j) == 1)
                {
                    string name = "";
                    if(j == 1) {
                        name = "1_1_1_sink";
                    } else if(j == 2) {
                        name = "1_1_1_toilet";
                    } else if(j == 3) {
                        name = "1_1_1_bed";
                    } else if(j == 4) {
                        name = "1_1_1_shaft";
                    } else if(j == 5) {
                        name = "1_1_1_door";
                    } else if(j == 6) {
                        name = "1_1_1_screen";
                    } else if(j == 7) {
                        name = "1_1_1_lights";
                    } else if(j == 8) {
                        name = "1_1_1_chair";
                    }
                    inspection.changeListener(name);
                }
            }
    }

    public GameObject[] getSaveFiles()
    {
        return savefiles;
    }

    public int getCount()
    {
        return savefiles.Length;
    }

}

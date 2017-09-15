﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Load LoadMenu;
    public Skip skip;
    public SpriteCon spriteCon;
    public Novel novel;
    public inspection inspection;
    public int currentBG = 0;
    public int gameMode = 0; //0 = reading, 1 = inspection, 2 = RPG (checks in the TextWrite script if to write or not)
    public bool enableWrite = true; // (checks in the TextBox script if to write or not. Only true during main storyline-text)
    private TextBox textbox;
    private int Char1;
    private int Char2;
    private int CharOn; // For loading function. 0 = 1on,2off, 1 = 1off,2on, 2 = 1on, 2on, 3 = 1off, 2off
    Vector3 moveCam;
    Color erase = new Color(0f,0f,0f,1f); //color to erase alpha
    private int runDisplay=0; // current displayRoutine to display
    private bool Ch1VisualsLoaded = false;

    public Sprite yes;
    public Sprite no;
    public Sprite confirmBG;
    GameObject InstanceContainer;
    GameObject question;
    GameObject yush;
    GameObject nope;
    private int selectedSave = 1;

    private void Awake()
    {
        // Prepare confirmWindow instantiator
        InstanceContainer = new GameObject("InstanceContainer");
        question = new GameObject("Confirm");
        yush = new GameObject("Yes");
        nope = new GameObject("No");
        question.transform.SetParent(InstanceContainer.transform, false);
        yush.transform.SetParent(InstanceContainer.transform, false);
        nope.transform.SetParent(InstanceContainer.transform, false);
        Image questionImg = question.AddComponent<Image>();
        Image yushImg = yush.AddComponent<Image>();
        Image nopeImg = nope.AddComponent<Image>();
        questionImg.sprite = confirmBG;
        yushImg.sprite = yes;
        nopeImg.sprite = no;
        questionImg.rectTransform.sizeDelta = new Vector2(400f, 250f);
        yushImg.rectTransform.sizeDelta = new Vector2(100f, 60f);
        nopeImg.rectTransform.sizeDelta = new Vector2(100f, 60f);
        Button btnYes = yush.AddComponent<Button>();
        Button btnNo = nope.AddComponent<Button>();

        GameObject.Find("NextPage").GetComponent<Button>().enabled = false;
        textbox = GameObject.Find("Textbox").GetComponent<TextBox>();
    }

    void Start () {
		if(novel.getCurrentLine() != -1) { //While not at beginning of Chapter
            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f);
            charAppear(1);
            charAppear(2);
            CharOn = 2;
        } else { //While at beginning of chapter
            charDisappear(1);
            charDisappear(2);
            CharOn = 3;

            GameObject.Find("BG1").GetComponent<SpriteRenderer>().color = GameObject.Find("BG1").GetComponent<SpriteRenderer>().color - erase; //BG Hidden
            GameObject.Find("BG2").GetComponent<SpriteRenderer>().color = GameObject.Find("BG2").GetComponent<SpriteRenderer>().color - erase; //BG Hidden

            textboxDisappear();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && runDisplay == 0 && novel.getCurrentLine() == 0)
        {
            StartCoroutine(DisplayCh0());
        }
        else if ((Input.GetKeyDown("space")||(skip.autoOn==true&& skip.skipOn == false) ||(skip.skipOn==true&&skip.autoOn==false)) 
            && runDisplay==0 && novel.getCurrentLine()>=8)
        {
            StartCoroutine(DisplayCh1());
        }

        if (gameMode == 1 && novel.getCurrentLine() == 14 && novel.savedIndex == 1)
        {
            
        }
    }

    IEnumerator DisplayCh1()
    {
        runDisplay = 1;
        if (novel.getCurrentLine() == 8 && Ch1VisualsLoaded == false)
        {
            enableWrite = false;
            Ch1VisualsLoaded = true;
            // Change Namebox
            GameObject.Find("T8").GetComponent<Text>().text = "Sabrina";
            // Jump to 2nd BG
            GameObject.Find("MainCam").GetComponent<Transform>().Translate(new Vector3(-24f, 0f, 0f));
            //BG slowly appears
            while (GameObject.Find("BG2").GetComponent<SpriteRenderer>().color.a != 1f)
            {
                GameObject.Find("BG2").GetComponent<SpriteRenderer>().color = GameObject.Find("BG2").GetComponent<SpriteRenderer>().color + new Color(0f, 0f, 0f, 0.2f);
                yield return new WaitForSeconds(0.08f);
            }
            currentBG = 2;
            CharOn = 1;
            enableWrite = true;
        }

        if (novel.getCurrentLine() == 9)
        {
            charAppear(2);
        }

        if (novel.getCurrentLine() == 14 && GameObject.Find("iO(Inst)1") == null && gameMode == 0)
        {
            //enable inspection mode
            gameMode = 1;
            //disable writing visuals
            charDisappear(2);
            stopWriting();
            textboxDisappear();

            GameObject.Find("TutorialPanel").GetComponent<RectTransform>().Translate(new Vector2(675f, 0f));
            GameObject.Find("CloseTutorialPanel").GetComponent<Button>().onClick.AddListener(()=> {
                GameObject.Find("TutorialPanel").GetComponent<RectTransform>().Translate(new Vector2(-675f, 0f));
                inspection.instObject(1, 300f, -50f, 80f, 70f, 1, 1); //sink
                inspection.instObject(2, 300f, -200f, 80f, 70f); //toillet
                inspection.instObject(3, -220f, -180f, 240f, 120f); //bed
                inspection.instObject(4, -30f, 225f, 80f, 50f); //ventilation shaft
                inspection.instObject(5, 220f, -30f, 120f, 320f); //door
                inspection.instObject(6, 90f, 60f, 100f, 100f, 2, 0); //screen
                inspection.instObject(7, 150f, 200f, 250f, 70f); //lights
                inspection.instObject(8, -20f, -100f, 80f, 90f); //chair
            });
        }

        while (novel.getCurrentLine() == 18 && GameObject.Find("NameBox").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            textboxAppear();
            yield return new WaitForSeconds(0.08f);
        }

        if (novel.getCurrentLine() == 18)
        {
            textboxDisappear();
        }

        runDisplay = 0;
    }

    IEnumerator DisplayCh0()
    {
        runDisplay = 1;
        GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(0f); //Title disappears
        GameObject.Find("Title").GetComponent<RectTransform>().position = GameObject.Find("Title").GetComponent<RectTransform>().localPosition = new Vector3(0f, 200f, 0f);

        if (novel.savedIndex == 1 && novel.getCurrentLine() == 0)
        {
            // Jump to 2nd BG
            GameObject.Find("MainCam").GetComponent<Transform>().Translate(new Vector3(12f, 0f, 0f));
            //BG slowly appears
            while (GameObject.Find("BG1").GetComponent<SpriteRenderer>().color.a != 1f)
            {
                GameObject.Find("BG1").GetComponent<SpriteRenderer>().color = GameObject.Find("BG1").GetComponent<SpriteRenderer>().color + new Color(0f, 0f, 0f, 0.2f);
                yield return new WaitForSeconds(0.08f);
            }
            currentBG = 1;
        }

        while (novel.getCurrentLine() < 9 && GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            //UI appears
            textboxAppear();
            yield return new WaitForSeconds(0.08f);
        }
        runDisplay = 0;
    }

    public void textboxAppear()
    {
        GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NameBox").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Skip").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Auto").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Load").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Menu").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

        GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T1").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T2").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T3").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T4").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T6").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T7").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

        GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
        GameObject.Find("Skip").GetComponent<Button>().enabled = true;
        GameObject.Find("Auto").GetComponent<Button>().enabled = true;
        GameObject.Find("SpeedUp").GetComponent<Button>().enabled = true;
        GameObject.Find("SpeedDown").GetComponent<Button>().enabled = true;
        GameObject.Find("Load").GetComponent<Button>().enabled = true;
        GameObject.Find("Menu").GetComponent<Button>().enabled = true;
        GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
    }

    public void textboxDisappear()
    {
        GameObject.Find("NameBox").GetComponent<Button>().enabled = false;
        GameObject.Find("Skip").GetComponent<Button>().enabled = false;
        GameObject.Find("Auto").GetComponent<Button>().enabled = false;
        GameObject.Find("SpeedUp").GetComponent<Button>().enabled = false;
        GameObject.Find("SpeedDown").GetComponent<Button>().enabled = false;
        GameObject.Find("Load").GetComponent<Button>().enabled = false;
        GameObject.Find("Menu").GetComponent<Button>().enabled = false;
        GameObject.Find("NameBox").GetComponent<Button>().enabled = false;

        GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
    }

    public void stopWriting()
    {
        enableWrite = false;
        Destroy(GameObject.Find("textwriter(Inst)" + textbox.txtWriterNr));
        GameObject.Find("Textbox").GetComponent<Text>().text = "";
    }

    //for externally changing char display
    public void charDisplay(int charOn)
    {
        // 0 = 1on,2off, 1 = 1off,2on, 2 = 1on, 2on, 3 = 1off, 2off
        switch (charOn)
        {
            case 0:
                charAppear(1);
                charDisappear(2);
                break;
            case 1:
                charDisappear(1);
                charAppear(2);
                break;
            case 2:
                charAppear(1);
                charAppear(2);
                break;
            case 3:
                charDisappear(1);
                charDisappear(2);
                break;
        }
    }

    public void confirmationWindow()
    {
        GameObject questInst = Instantiate(question);
        GameObject yushInst = Instantiate(yush);
        GameObject nopeInst = Instantiate(nope);
        questInst.transform.SetParent(GameObject.Find("Canvas").transform, false);
        yushInst.transform.SetParent(questInst.transform, false);
        nopeInst.transform.SetParent(questInst.transform, false);

        questInst.GetComponent<Image>().rectTransform.position = new Vector3(350f, 250f, 0f);
        yushInst.GetComponent<Image>().rectTransform.localPosition = new Vector3(-75f, 0f, 0f);
        nopeInst.GetComponent<Image>().rectTransform.localPosition = new Vector3(75f, 0f, 0f);

        yushInst.GetComponent<Button>().onClick.AddListener(() => { LoadMenu.loadData(selectedSave); Destroy(questInst); });
        nopeInst.GetComponent<Button>().onClick.AddListener(() => { Destroy(questInst); });
    }

    void charAppear(int i)
    {
        //TODO: char selection parameter
        // let char avatars appear during talk
        GameObject.Find("Char" + i).GetComponent<CanvasRenderer>().SetAlpha(1f);
    }

    void charDisappear(int i)
    {
        //TODO: char selection parameter
        // let char avatars disappear during talk
        GameObject.Find("Char" + i).GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    void CharOutgrey(int i)
    {
        // Char Outgrey while present but not talking
        GameObject.Find("Char" + i).GetComponent<CanvasRenderer>().SetColor(new Color(0.2f, 0.2f, 0.2f));
    }

    void switchChar1()
    {
        GameObject.Find("Char1").GetComponentInChildren<Image>().sprite = spriteCon.c1;
    }

    void switchChar2()
    {
        GameObject.Find("Char2").GetComponentInChildren<Image>().sprite = spriteCon.c2;
    }

    public int getChar1() {
        return Char1;
    }

    public int getChar2()
    {
        return Char2;
    }

    public int getCharOn()
    {
        return CharOn;
    }

    public void setCharOn(int i)
    {
        CharOn = i;
    }

    public void setSelectedSave(int i)
    {
        selectedSave = i;
    }
}

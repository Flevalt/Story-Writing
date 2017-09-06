using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public TextWrite wr;
    public SpriteCon spriteCon;
    public Novel novel;
    public int currentBG;
    private int Char1;
    private int Char2;
    Vector3 moveCam;
    Color erase = new Color(0f,0f,0f,1f); //color to erase alpha
    private int runDisplay=0; // current displayRoutine to display

    // Use this for initialization
    void Start () {
		if(novel.getCurrentLine() != -1) { //While not at beginning of Chapter
            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f);
            charAppear(1);
            charAppear(2);
        } else { //While at beginning of chapter
            charDisappear(1);
            charDisappear(2);

            GameObject.Find("BG1").GetComponent<SpriteRenderer>().color = GameObject.Find("BG1").GetComponent<SpriteRenderer>().color - erase; //BG Hidden
            GameObject.Find("BG2").GetComponent<SpriteRenderer>().color = GameObject.Find("BG2").GetComponent<SpriteRenderer>().color - erase; //BG Hidden

            GameObject.Find("NameBox").GetComponent<Button>().enabled = false;
            GameObject.Find("Skip").GetComponent<Button>().enabled = false;
            GameObject.Find("Auto").GetComponent<Button>().enabled = false;
            GameObject.Find("SpeedUp").GetComponent<Button>().enabled = false;
            GameObject.Find("SpeedDown").GetComponent<Button>().enabled = false;
            GameObject.Find("Save").GetComponent<Button>().enabled = false;
            GameObject.Find("Load").GetComponent<Button>().enabled = false;
            GameObject.Find("Menu").GetComponent<Button>().enabled = false;
            GameObject.Find("NameBox").GetComponent<Button>().enabled = false;

            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Save").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T5").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && runDisplay == 0 && novel.getCurrentLine() == -1)
        {
            StartCoroutine(DisplayCh0());
        } else if (Input.GetKeyDown("space") && runDisplay==0 && novel.getCurrentLine()==8)
        {
            StartCoroutine(DisplayCh1());
        } 
    }

    IEnumerator DisplayCh1()
    {
        runDisplay = 1;
        if (novel.savedIndex == 1 && novel.getCurrentLine() == 8)
        {
            // Jump to 2nd BG
            GameObject.Find("MainCam").GetComponent<Transform>().Translate(new Vector3(-24f, 0f, 0f));
            //BG slowly appears
            while (GameObject.Find("BG2").GetComponent<SpriteRenderer>().color.a != 1f)
            {
                GameObject.Find("BG2").GetComponent<SpriteRenderer>().color = GameObject.Find("BG2").GetComponent<SpriteRenderer>().color + new Color(0f, 0f, 0f, 0.2f);
                yield return new WaitForSeconds(0.08f);
            }
            currentBG = 2;
            charAppear(2);
        }
        runDisplay = 0;
    }

    IEnumerator DisplayCh0()
    {
        runDisplay = 1;
        GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(0f); //Title disappears

        if (novel.savedIndex == 1 && novel.getCurrentLine() == -1)
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

        while (novel.getCurrentLine() < 8 && GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            //UI appears
            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NameBox").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Skip").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Auto").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Save").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Save").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Load").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Menu").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

            GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T1").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T2").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T3").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T4").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T5").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T5").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T6").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T7").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

            GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
            GameObject.Find("Skip").GetComponent<Button>().enabled = true;
            GameObject.Find("Auto").GetComponent<Button>().enabled = true;
            GameObject.Find("SpeedUp").GetComponent<Button>().enabled = true;
            GameObject.Find("SpeedDown").GetComponent<Button>().enabled = true;
            GameObject.Find("Save").GetComponent<Button>().enabled = true;
            GameObject.Find("Load").GetComponent<Button>().enabled = true;
            GameObject.Find("Menu").GetComponent<Button>().enabled = true;
            GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
            yield return new WaitForSeconds(0.08f);
        }
        runDisplay = 0;
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
}

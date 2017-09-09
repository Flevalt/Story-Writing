using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {

    public Novel novel; //External script of Novel
    public Text textbox; //Textbox element
    public Controller controller;
    public bool run; // turns true while text is being written in the textbox
    public bool started = false; // turns true when title is not displayed
    private bool loaded = false; // true if player just loaded savefile
    private float f = 0.02f; //write delay

	// Use this for initialization
	void Start () {
        textbox = GameObject.Find("Textbox").GetComponent<Text>(); //textbox element
    }

    public void attemptWriting(int i) {
        if (GameObject.Find("BG" + i).GetComponent<SpriteRenderer>().color.a == 1f && run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            run = true;
            StartCoroutine(ReadChapter(textbox.text, novel.getCurrentLine()+1, novel.getCurrentCh(novel.savedIndex))); //reads chapter lines with selected textbox, current line and current chapter content
            novel.setCurrentLine(novel.getCurrentLine() + 1);
        }
    }

    private void Update()
    {
            if (run==false && Input.GetKeyDown("space"))
            {
                loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
                started = true;
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
                textbox.text = "";
                attemptWriting(controller.currentBG); //name each BG after the linenumber
            }
    }

    IEnumerator ReadChapter(string str, int currLine, string[] currCh)
    {
            str = currCh[currLine];
            for (int i = 0; i < str.Length; i++)
            {
            if (loaded == false) // If load is pressed during readChapter, cancel readChapter
            {
                textbox.text = textbox.text + str[i];
                yield return new WaitForSeconds(f);
            }
            }

            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NextPage").GetComponent<CanvasRenderer>().GetAlpha() + 1f);
            run = false;
            loaded = false; // Reset loaded at end of the writing sequence
    }

    public float getF()
    {
        return f;
    }

    public void setF(float fl)
    {
        f = fl;
    }

    public void setRun(bool b)
    {
        run = b;
    }

    public void setLoaded(bool b)
    {
        loaded = b;
    }

}

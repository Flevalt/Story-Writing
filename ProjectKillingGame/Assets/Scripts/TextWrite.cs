using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {

    private Novel novel; //External script of Novel
    private Text textbox; //Textbox element
    private Controller controller; //Controller element
    private Skip skip;
    private float f = 0.02f;

    public bool autoin = false;
    public bool skippin = false;
    public bool run = false; // turns true while text is being written in the textbox
    public bool started = false; // turns true when title is not displayed
    private bool loaded = false; // true if player just loaded savefile

	// Use this for initialization
	void Awake () {
        skip = GameObject.Find("Skip").GetComponent<Skip>();
        textbox = GameObject.Find("Textbox").GetComponent<Text>();
        novel = GameObject.Find("NovelStorage").GetComponent<Novel>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    public void attemptWriting() {
        if (run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
            started = true;
            textbox.text = "";
            StartCoroutine(ReadChapter(novel.getCurrentLine()+1, novel.getCurrentCh(novel.savedIndex))); //reads chapter lines with selected textbox, current line and current chapter content
            novel.setCurrentLine(novel.getCurrentLine() + 1);
        }
    }

    public void attemptAuto()
    {
        if (run == false && skip.autoOn == true && skip.skipOn == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
            started = true;
            textbox.text = "";
            StartCoroutine(AutoReadChapter(novel.getCurrentLine() + 1, novel.getCurrentCh(novel.savedIndex))); //reads chapter lines with selected textbox, current line and current chapter content
            novel.setCurrentLine(novel.getCurrentLine() + 1);
        }
    }

    public void attemptSkip()
    {
        if (run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
            started = true;
            textbox.text = "";
            StartCoroutine(SkipReadChapter(novel.getCurrentLine() + 1, novel.getCurrentCh(novel.savedIndex))); //reads chapter lines with selected textbox, current line and current chapter content
            novel.setCurrentLine(novel.getCurrentLine() + 1);
        }
    }

    IEnumerator SkipReadChapter(int currLine, string[] currCh)
    {
        skippin = true;
        run = true;
        if (novel.getCurrentLine() == -1)
        {
            yield return new WaitForSeconds(1);
        }
        string str = currCh[currLine];
        for (int i = 0; i < str.Length; i++)
        {
            if (loaded == false) // If load is pressed during readChapter, cancel readChapter
            {
                textbox.text = textbox.text + str[i];
                yield return new WaitForSeconds(0); //fullspeed read without waiting time
            }
        }
        GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NextPage").GetComponent<CanvasRenderer>().GetAlpha() + 1f);
        run = false;
        loaded = false; // Reset loaded at end of the writing sequence
        skippin = false;
    }

    IEnumerator AutoReadChapter(int currLine, string[] currCh)
    {
        autoin = true;
        run = true;
        if (novel.getCurrentLine() == -1)
        {
            yield return new WaitForSeconds(1);
        }
        string str = currCh[currLine];
        for (int i = 0; i < str.Length; i++)
        {
            if (loaded == false) // If load is pressed during readChapter, cancel readChapter
            {
                textbox.text = textbox.text + str[i];
                yield return new WaitForSeconds(f);
            }
        }

        GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NextPage").GetComponent<CanvasRenderer>().GetAlpha() + 1f);
        yield return new WaitForSeconds(2);
        run = false;
        loaded = false; // Reset loaded at end of the writing sequence
        autoin = false;
        attemptAuto();
    }

    IEnumerator ReadChapter(int currLine, string[] currCh)
    {
        run = true;
        if (novel.getCurrentLine() == -1)
        {
            yield return new WaitForSeconds(1);
        }
            string str = currCh[currLine];
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

    public void setRun(bool b)
    {
        run = b;
    }

    public void setLoaded(bool b)
    {
        loaded = b;
    }

    public float getF()
    {
        return f;
    }

    public void setF(float fl)
    {
        f = fl;

    }

}

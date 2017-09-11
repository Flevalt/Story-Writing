using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {

    private Novel novel; //External script of Novel
    private Text textbox; //Textbox element
    private Controller controller; //Controller element
    private float f = 0.02f;

    public bool run = false; // turns true while text is being written in the textbox
    public bool started = false; // turns true when title is not displayed
    private bool loaded = false; // true if player just loaded savefile

	// Use this for initialization
	void Awake () {
        textbox = GameObject.Find("Textbox").GetComponent<Text>();
        novel = GameObject.Find("NovelStorage").GetComponent<Novel>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    public void attemptWriting(int i) {
        if (run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
            started = true;
            textbox.text = "";
            StartCoroutine(ReadChapter(novel.getCurrentLine()+1, novel.getCurrentCh(novel.savedIndex))); //reads chapter lines with selected textbox, current line and current chapter content
            novel.setCurrentLine(novel.getCurrentLine() + 1);
        }
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

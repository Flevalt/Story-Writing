using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {

    public Novel novel; //External script of Novel
    private string[] currCh; //Currently loaded Chapter
    public Text textbox; //Textbox element
    public bool run; // turns true while text is being written in the textbox
    public bool started = false; // turns true when title is not displayed
    private float f = 0.02f; //write delay

	// Use this for initialization
	void Start () {
        textbox = GameObject.Find("Textbox").GetComponent<Text>(); //textbox element
        currCh = novel.getCurrentCh(novel.savedIndex); //loads chapter
    }

    public void attemptWriting() {
        if (GameObject.Find("BG1").GetComponent<SpriteRenderer>().color.a == 1f && run == false) //Check every frame if in middle of chapter, otherwise do not read
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
                started = true;
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
                textbox.text = "";
                attemptWriting();
            }
    }

    IEnumerator ReadChapter(string str, int currLine, string[] currCh)
    {
            str = currCh[currLine];
            for (int i = 0; i < str.Length; i++)
            {
                textbox.text = textbox.text + str[i];
                yield return new WaitForSeconds(f);
            }

            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NextPage").GetComponent<CanvasRenderer>().GetAlpha() + 1f);
            run = false;
    }

    public float getF()
    {
        return f;
    }

    public void setF(float fl)
    {
        f = fl;
    }

    public void finishLine()
    {
        textbox.text = currCh[0];
    }

}

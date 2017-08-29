using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {

    public Novel novel; //External script of Novel
    public string[] currCh; //Currently loaded Chapter
    private int curr = 1; //current Chapter-index
    private int currentLine = 0;
    public Text textbox; //Textbox element
    public GUIText txt2;

	// Use this for initialization
	void Start () {
        textbox = GameObject.Find("Textbox").GetComponent<Text>(); //textbox element
        currCh = novel.getCurrentCh(novel.savedIndex); //loads chapter
        StartCoroutine(ReadChapter(textbox.text, currentLine, currCh)); //reads chapter lines
	}

    IEnumerator ReadChapter(string str, int currLine, string[] currCh)
    {
        float f = 0.05f;
        str = currCh[currLine];
        for (int i=0; i<str.Length; i++)
        {
            textbox.text = textbox.text + str[i];
            yield return new WaitForSeconds(f);
        }
        
    }

    public void finishLine()
    {
        textbox.text = currCh[0];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleWrite : MonoBehaviour {

    private TextBox textbox;
    private TextWrite wr;
    public Novel novel;
    private Text dispText;

    // Use this for initialization
    void Start () {
        textbox = GameObject.Find("Textbox").GetComponent<TextBox>();
        wr = GameObject.Find("textwriter(Inst)" + textbox.txtWriterNr).GetComponent<TextWrite>();
        GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(0.0f); //Make Title invisible by default
        GameObject.Find("Title").GetComponent<RectTransform>().localPosition = new Vector3(0f, 200f, 0f);
        if (novel.getCurrentLine() == -1) //Only load title if at beginning of a chapter
        {
            StartCoroutine(DisplayTitle());
        }
    }

    //external call of displayTitle
    public void displayTitle(int titleId, int colorId)
    {
        Debug.Log("displayTitle");
        setTitle(titleId, colorId);
        StartCoroutine(displaySmallTitles());
    }

    //displays titles that are not the beginning
    IEnumerator displaySmallTitles()
    {
        GameObject.Find("Title").GetComponent<RectTransform>().localPosition = new Vector3(-9f, 30f, 0f);
        while (GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() + 0.025f);
            yield return new WaitForSeconds(0.08f);
        }
    }

    //Fades in the title at the start
    IEnumerator DisplayTitle ()
    {
        GameObject.Find("Title").GetComponent<RectTransform>().localPosition = new Vector3(-9f, 30f, 0f);
        while (wr.started == false && novel.getCurrentLine() == -1 && GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() != 1.0f)
        {
            GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() + 0.025f);
            yield return new WaitForSeconds(0.08f);
        }
    }

    //takes Chapter index and returns the Title text to be displayed

    private void setTitle(int index, int color)
    {
        switch (color)
        {
            case 0:
                GameObject.Find("Title").GetComponent<Text>().color = new Color(1f, 1f, 1f);
                break;
        }

        switch (index)
        {
            case 1:
                GameObject.Find("Title").GetComponent<Text>().text = "~ Chapter 1 ~";
                break;
            case 2:
                GameObject.Find("Title").GetComponent<Text>().text = "~ Chapter 2 ~";
                break;
            case 3:
                GameObject.Find("Title").GetComponent<Text>().text = "~ Chapter 3 ~";
                break;
            case 4:
                GameObject.Find("Title").GetComponent<Text>().text = "...30 minutes later...";
                break; 
            case 5:
                GameObject.Find("Title").GetComponent<Text>().text = "...2 hours later...";
                break; 
            default:
                GameObject.Find("Title").GetComponent<Text>().text = "~ Prologue ~";
                break;
        }
        
    }

    public void setTextWrite(TextWrite tw)
    {
        wr = tw;
    }

}

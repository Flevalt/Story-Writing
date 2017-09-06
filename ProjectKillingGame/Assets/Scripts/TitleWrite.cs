﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleWrite : MonoBehaviour {

    public TextWrite wr;
    public Novel novel;
    Text dispText;

    // Use this for initialization
    void Start () {
        GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(0.0f); //Make Title invisible by default
        pickTitle(novel.savedIndex);    //Pick current title
        if (novel.getCurrentLine() == -1) //Only load title if at beginning of a chapter
        {
            StartCoroutine(DisplayTitle());
        }
    }

    //Fades in the title
    IEnumerator DisplayTitle ()
    {
        while (wr.started == false && novel.getCurrentLine() == -1 && GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() != 1.0f)
        {
            GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Title").GetComponent<CanvasRenderer>().GetAlpha() + 0.025f);
            yield return new WaitForSeconds(0.08f);
        }
    }

    //takes Chapter index and returns the Title text to be displayed
    string pickTitle(int index)
    {
        switch (index)
        {
            case 1:
                return "~ Chapter 1 ~";
            case 2:
                return "~ Chapter 2 ~";
            case 3:
                return "~ Chapter 3 ~";
            default:
                return "~ Prologue ~";
        }
    }

}
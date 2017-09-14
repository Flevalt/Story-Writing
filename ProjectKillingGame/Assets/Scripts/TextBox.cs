﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour {

    private GameObject textwriter;
    private Controller controller;
    private Skip skip;
    GameObject textwr;
    private float f = 0.02f; //write delay, aka textspeed
    public int txtWriterNr = 1;

    private void Awake()
    {
        skip = GameObject.Find("Skip").GetComponent<Skip>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        textwriter = new GameObject("textwriter"); //textwriter

        textwr = Instantiate(textwriter); //instance of textwriter
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite>(); //add functionality to textwriter instance
    }
	
	void Update () {
        if (textwr == null) {
            textwr = GameObject.Find("textwriter(Inst)" + txtWriterNr);
        }
        // Only attempt writing at all if controller hasn't disabled it
        if (controller.enableWrite == true && controller.gameMode == 0)
        {
        //Auto-call
        if (skip.skipOn == false && skip.autoOn == true && textwr.GetComponent<TextWrite>().run == false)
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptAuto();
        }
        //Skip-call only if skippin isn't currently running for the 2nd time
            else if (skip.skipOn == true && skip.autoOn == false && (textwr.GetComponent<TextWrite>().run == false || textwr.GetComponent<TextWrite>().skippin == false))
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
                txtWriterNr += 1;
                textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptSkip();
            //Normal ReadChapter-call
        } else if (Input.GetKeyDown("space") && skip.skipOn == skip.autoOn)
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
                txtWriterNr += 1;
                textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptWriting();
        }
        }
    }

    public float getF()
    {
        return f;
    }

    public void setF(float fl)
    {
        f = fl;
        GameObject.Find("textwriter(Inst)").GetComponent<TextWrite>().setF(fl);
    }

}

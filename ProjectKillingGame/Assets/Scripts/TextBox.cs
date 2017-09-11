using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour {

    private GameObject textwriter;
    private Controller controller;
    private float f = 0.02f; //write delay, aka textspeed

    private void Awake()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        textwriter = new GameObject("textwriter"); //textwriter
    }

    void Start () {
        GameObject textwr = Instantiate(textwriter); //instance of textwriter
        textwr.name = "textwriter(Inst)";
        textwr.AddComponent<TextWrite>(); //add functionality to textwriter instance
        
    }
	
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)"));
            GameObject textwr = Instantiate(textwriter);
            textwr.name = "textwriter(Inst)";
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptWriting(controller.currentBG);
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

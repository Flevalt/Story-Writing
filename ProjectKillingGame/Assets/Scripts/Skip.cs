using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour {

    private TextWrite tw;
    private Text tb;
    private Novel novel;
    public bool skipOn = false;
    public bool autoOn = false;

	void Awake () {

	}

    private void Start()
    {
        tb = GameObject.Find("Textbox").GetComponent<Text>();
        novel = GameObject.Find("NovelStorage").GetComponent<Novel>();
        tw = GameObject.Find("textwriter(Inst)").GetComponent<TextWrite>();
    }

    public void skipDatShit()
    {
        if (skipOn == true)
        {
            skipOn = false;
            GameObject.Find("Skip").GetComponent<Image>().color = GameObject.Find("Skip").GetComponent<Image>().color - new Color(0f, 1f, 0f) + new Color(1f, 0f, 0f);
        } else
        {
            skipOn = true;
            GameObject.Find("Skip").GetComponent<Image>().color = GameObject.Find("Skip").GetComponent<Image>().color - new Color(1f, 0f, 0f) + new Color(0f, 1f, 0f);
        }
    }

    public void autoRead()
    {
        if (autoOn == true)
        {
            autoOn = false;
            GameObject.Find("Auto").GetComponent<Image>().color = GameObject.Find("Auto").GetComponent<Image>().color - new Color(0f, 1f, 0f) + new Color(1f, 0f, 0f);
        } else
        {
            autoOn = true;
            GameObject.Find("Auto").GetComponent<Image>().color = GameObject.Find("Auto").GetComponent<Image>().color - new Color(1f, 0f, 0f) + new Color(0f, 1f, 0f);
        }

    }
}

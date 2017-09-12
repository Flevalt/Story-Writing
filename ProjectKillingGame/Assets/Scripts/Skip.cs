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

        } else
        {
            skipOn = true;
            for (int j = 0; j < novel.getCurrentCh(novel.savedIndex).Length; j++)
            {
                tb.text = novel.getCurrentCh(novel.savedIndex)[novel.getCurrentLine()];
                novel.setCurrentLine(novel.getCurrentLine() + 1);
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }

    public void autoRead()
    {
        if (autoOn == true)
        {
            autoOn = false;


        } else
        {
            autoOn = true;

        }

    }
}

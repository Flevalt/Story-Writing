using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public TextWrite wr;
    public Novel novel;
    Vector3 moveCam;
    Color erase = new Color(0f,0f,0f,1f); //color to erase alpha
    private bool runDisplay=false;

    // Use this for initialization
    void Start () {
		if(novel.getCurrentLine() != -1) { //While not at beginning of Chapter
            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f); //
        } else { //While at beginning of chapter
            GameObject.Find("BG1").GetComponent<SpriteRenderer>().color = GameObject.Find("BG1").GetComponent<SpriteRenderer>().color - erase; //BG Hidden

            GameObject.Find("NameBox").GetComponent<Button>().enabled = false;
            GameObject.Find("Skip").GetComponent<Button>().enabled = false;
            GameObject.Find("Auto").GetComponent<Button>().enabled = false;
            GameObject.Find("SpeedUp").GetComponent<Button>().enabled = false;
            GameObject.Find("SpeedDown").GetComponent<Button>().enabled = false;
            GameObject.Find("Save").GetComponent<Button>().enabled = false;
            GameObject.Find("Load").GetComponent<Button>().enabled = false;
            GameObject.Find("Menu").GetComponent<Button>().enabled = false;
            GameObject.Find("NameBox").GetComponent<Button>().enabled = false;

            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Save").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T5").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
            GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0.00f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && wr.run == false && runDisplay == false)
        {
            StartCoroutine(DisplayCh1());
        }
    }

    IEnumerator DisplayCh1()
    {
        runDisplay = true;
        GameObject.Find("Title").GetComponent<CanvasRenderer>().SetAlpha(0f); //Title disappears
        if (novel.savedIndex == 1 && novel.getCurrentLine() == -1)
        {
            // Jump to 2nd Scene
            GameObject.Find("MainCam").GetComponent<Transform>().Translate(new Vector3(12f, 0f, 0f));
            //BG slowly appears
            while (GameObject.Find("BG1").GetComponent<SpriteRenderer>().color.a != 1f)
            {
                GameObject.Find("BG1").GetComponent<SpriteRenderer>().color = GameObject.Find("BG1").GetComponent<SpriteRenderer>().color + new Color(0f, 0f, 0f, 0.2f);
                yield return new WaitForSeconds(0.08f);
            }
        }
        while (novel.getCurrentLine() < 10 && GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() != 1f)
        {
            //UI appears
            GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("NameBox").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Skip").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Skip").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Auto").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Auto").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedUp").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("SpeedDown").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Save").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Save").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Load").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Load").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Menu").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Menu").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

            GameObject.Find("T1").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T1").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T2").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T2").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T3").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T3").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T4").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T4").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T5").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T5").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T6").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T6").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T7").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T7").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("T8").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);

            GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
            GameObject.Find("Skip").GetComponent<Button>().enabled = true;
            GameObject.Find("Auto").GetComponent<Button>().enabled = true;
            GameObject.Find("SpeedUp").GetComponent<Button>().enabled = true;
            GameObject.Find("SpeedDown").GetComponent<Button>().enabled = true;
            GameObject.Find("Save").GetComponent<Button>().enabled = true;
            GameObject.Find("Load").GetComponent<Button>().enabled = true;
            GameObject.Find("Menu").GetComponent<Button>().enabled = true;
            GameObject.Find("NameBox").GetComponent<Button>().enabled = true;
            yield return new WaitForSeconds(0.08f);
        }
        runDisplay = false;
    }
}

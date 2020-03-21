using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Responsible for outputting the text to the TextBox.
 */

public class TextWrite : MonoBehaviour {

    private Novel novel; //External script of Novel
    private Controller controller; //Controller element
    private TextBox textbox;
    private TextMeshProUGUI textboxTextField; //Textbox element
    private Skip skip;
    private float f = 0.02f;

    public int writeCheck;
    public bool autoin = false;
    public bool skippin = false;
    public bool run = false; // turns true while text is being written in the textboxTextField
    public bool started = false; // turns true when title is not displayed
    private bool loaded = false; // true if player just loaded savefile
    private bool loadedNextLine = false; // true if the next line is being written already

    // Use this for initialization
    void Awake () {
        textbox = GameObject.Find ("Textbox").GetComponent<TextBox> ();
        textboxTextField = GameObject.Find ("Textbox").GetComponent<TextMeshProUGUI> ();
        skip = GameObject.Find ("Skip").GetComponent<Skip> ();
        novel = GameObject.Find ("NovelStorage").GetComponent<Novel> ();
        controller = GameObject.Find ("Controller").GetComponent<Controller> ();
    }

    /**
     * WRITING FUNCTIONS
     */
    //normal writing function but without increasing linecount
    public void attemptInspectionWriting () {
        writeCheck = textbox.txtWriterNr;
        setupWriting ();
        StartCoroutine (ReadChapter (novel.getCurrentLine (), novel.getCurrentCh (novel.savedIndex)));
    }

    public void attemptWriting () {
        if (run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            writeCheck = textbox.txtWriterNr;
            setupWriting ();
            StartCoroutine (ReadChapter (novel.getCurrentLine () + 1, novel.getCurrentCh (novel.savedIndex))); //reads chapter lines with selected textboxTextField, current line and current chapter content
            novel.setCurrentLine (novel.getCurrentLine () + 1);
        }
    }

    public void attemptAuto () {
        if (run == false && skip.autoOn == true && skip.skipOn == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            setupWriting ();
            StartCoroutine (AutoReadChapter (novel.getCurrentLine () + 1, novel.getCurrentCh (novel.savedIndex))); //reads chapter lines with selected textboxTextField, current line and current chapter content
            novel.setCurrentLine (novel.getCurrentLine () + 1);
        }
    }

    public void attemptSkip () {
        if (run == false) //Check every frame if in middle of chapter, otherwise do not read
        {
            setupWriting ();
            StartCoroutine (SkipReadChapter (novel.getCurrentLine () + 1, novel.getCurrentCh (novel.savedIndex))); //reads chapter lines with selected textboxTextField, current line and current chapter content
            novel.setCurrentLine (novel.getCurrentLine () + 1);
        }
    }

    private void setupWriting () {
        loaded = false; //Reset loaded at beginning of the next writing sequence, in case the player pressed load AFTER the end of writing sequence
        started = true;
        textboxTextField.text = "";
    }

    IEnumerator SkipReadChapter (int currLine, string[] currCh) {
        skippin = true;
        run = true;
        if (novel.getCurrentLine () == -1) {
            yield return new WaitForSeconds (1);
        }
        string str = currCh[currLine];
        if (controller.gameMode == "reading") {
            for (int i = 0; i < str.Length; i++) {
                if (loaded == false) // If load is pressed during readChapter, cancel readChapter
                {
                    textboxTextField.text = textboxTextField.text + str[i];
                    yield return new WaitForSeconds (0); //fullspeed read without waiting time
                }
            }
        }

        if (controller.gameMode == "reading") {
            GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().GetAlpha () + 1f);
        }
        run = false;
        loaded = false; // Reset loaded at end of the writing sequence
        skippin = false;
    }

    IEnumerator AutoReadChapter (int currLine, string[] currCh) {
        autoin = true;
        run = true;
        if (novel.getCurrentLine () == -1) {
            yield return new WaitForSeconds (1);
        }
        string str = currCh[currLine];
        if (controller.gameMode == "reading") {
            for (int i = 0; i < str.Length; i++) {
                if (loaded == false) // If load is pressed during readChapter, cancel readChapter
                {
                    textboxTextField.text = textboxTextField.text + str[i];
                    yield return new WaitForSeconds (f);
                }
            }
        }

        if (controller.gameMode == "reading") {
            GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().GetAlpha () + 1f);
            yield return new WaitForSeconds (2);
        }
        run = false;
        loaded = false; // Reset loaded at end of the writing sequence
        autoin = false;
        attemptAuto ();
    }

    IEnumerator ReadChapter (int currLine, string[] currCh) {
        run = true;
        if (novel.getCurrentLine () == -1) {
            yield return new WaitForSeconds (1);
        }
        string str = currCh[currLine];
        if (controller.gameMode == "reading") {
            for (int i = 0; i < str.Length; i++) {
                if (loaded == false && loadedNextLine == false && (textbox.txtWriterNr == writeCheck)) // If load is pressed during readChapter, cancel readChapter
                {
                    textboxTextField.text = textboxTextField.text + str[i];
                    yield return new WaitForSeconds (f);
                }
            }
        }

        if (controller.gameMode == "reading") {
            GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().GetAlpha () + 1f);
        }
        run = false;
        loaded = false; // Reset loaded at end of the writing sequence
    }

    public void setRun (bool b) {
        run = b;
    }

    public void setLoaded (bool b) {
        loaded = b;
    }

    public float getF () {
        return f;
    }

    public void setF (float fl) {
        f = fl;

    }

}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Switches between the different chapters & game modes.
 * Also serves as model that holds the game's state.
 */
public class Controller : MonoBehaviour {

    /**
     * Public Manager Objects
     */
    public GameObject namebox;
    public GameObject nameboxText;
    public TextBox textbox;
    public UIManager UIManager;
    public Load LoadMenu;
    public Novel novel;
    public Inspection inspection;
    public TitleWrite titlewrite;

    /**
     * GAME STATES
     */
    public int currentBG = 0; // exclusively used for Save/Load functionality
    public string gameMode = ""; //reading, inspection, CorridorWalk, RPG/Hellgate, ?? (checks in the TextWrite script if to write or not)
    public bool enableWrite = true; // (checks in the TextBox script if to write or not. Only true during main storyline-text)
    private int runDisplay = 0; // current displayRoutine to display
    private bool Ch1VisualsLoaded = false;
    public int coinAmount; //obtained coin amount
    public int decision; //decision id for decision

    /**
     * SAVE/LOAD Variables
     */
    public int selectedSave = 1;
    private int Char1;
    private int Char2;
    public int CharOn; //State of the TextBox's Char Slots
    // For loading function. 0 = 1on,2off, 1 = 1off,2on, 2 = 1on, 2on, 3 = 1off, 2off
    //Also used for charDisplay calls in TextBox

    void Start () {
        gameMode = "reading";
        //Only load title if at beginning of a chapter
        if (novel.currentChapter == 0 && novel.currentLine == -1) {
            titlewrite.fadeInTitle ("~ Prologue ~", Color.white, 0.025f);
        }
    }

    void Update () {
        if (gameMode == "corridorWalk") {
            phase1Start ();
        }
    }

    // Intro with planet
    public void startCh0 () {
        DisplayCh0 ();
    }
    // Sabrina wakes up in her room.
    public void startCh1 () {
        runDisplay = 1;

        if (Ch1VisualsLoaded == false) {
            UIManager.charAppear (2);
            Ch1VisualsLoaded = true;
            changeNameBoxText ("Sabrina");
            UIManager.changeBG ("SabrinasRoom");

            currentBG = 2;
            CharOn = 1;
        }

        runDisplay = 0;
    }
    // Inspection Mode of Ch 1.1.1
    public void startCh1_1_1 () {
        runDisplay = 1;

        if (novel.currentLine == 8 && GameObject.Find ("sink") == null && gameMode == "reading") {
           inspection.startInspectionMode ();
            GameObject.Find ("TutorialPanel").GetComponent<RectTransform> ().Translate (new Vector2 (675f, 0f));
            GameObject.Find ("CloseTutorialPanel").GetComponent<Button> ().onClick.AddListener (() => {
                GameObject.Find ("TutorialPanel").GetComponent<RectTransform> ().Translate (new Vector2 (-675f, 0f));
                inspection.createInspectionElements ();
                inspection.disableNavForInspectionElems ();
            });
        }

        runDisplay = 0;
    }
    public void startCh1_2 () {
        runDisplay = 1;
        runDisplay = 0;
    }
    public void startCh1_3 () {
        runDisplay = 1;
        runDisplay = 0;
    }
    public void startCh1_4 () {
        runDisplay = 1;
        runDisplay = 0;
    }
    // Sabrina interacts with the door.
    public void startCh1_1 () {
        StartCoroutine (DisplayCh1_1 ());
    }

    void changeNameBoxText (string name) {
        nameboxText.GetComponent<Text> ().text = name;
    }

    //Planet appears
    void DisplayCh0 () {
        runDisplay = 1;
        //titlewrite disappears
        titlewrite.hideTitle ();

        //BG appears
        if (novel.currentChapter == 0 && novel.currentLine == -1) {
            UIManager.changeBG ("Prologue");
            currentBG = 1;
        }
        UIManager.textboxAppear ();
        runDisplay = 0;
    }

    IEnumerator DisplayCh1_1 () {
        while (namebox.GetComponent<CanvasRenderer> ().GetAlpha () != 1f) {
            UIManager.textboxAppear ();
            yield return new WaitForSeconds (0.08f);
        }
    }

    public void stopWriting () {
        enableWrite = false;
        Destroy (GameObject.Find ("textwriter(Inst)" + textbox.txtWriterNr));
        textbox.GetComponent<TextMeshProUGUI> ().text = "";
    }

    public void phase1Start () {
        if (Input.GetKey ("w")) {
            GameObject.Find ("ChibiSabrina").GetComponent<Transform> ().localPosition += new Vector3 (0f, 0.01f, 0f);
            GameObject.Find ("Light1").GetComponent<Transform> ().localPosition += new Vector3 (0f, 0.01f, 0f);
        } else if (Input.GetKey ("a")) {
            GameObject.Find ("ChibiSabrina").GetComponent<Transform> ().localPosition -= new Vector3 (0.01f, 0f, 0f);
            GameObject.Find ("Light1").GetComponent<Transform> ().localPosition -= new Vector3 (0.01f, 0f, 0f);
        } else if (Input.GetKey ("s")) {
            GameObject.Find ("ChibiSabrina").GetComponent<Transform> ().localPosition -= new Vector3 (0f, 0.01f, 0f);
            GameObject.Find ("Light1").GetComponent<Transform> ().localPosition -= new Vector3 (0f, 0.01f, 0f);
        } else if (Input.GetKey ("d")) {
            GameObject.Find ("ChibiSabrina").GetComponent<Transform> ().localPosition += new Vector3 (0.01f, 0f, 0f);
            GameObject.Find ("Light1").GetComponent<Transform> ().localPosition += new Vector3 (0.01f, 0f, 0f);
        }
    }

    public int getCharOn () {
        return CharOn;
    }

    public void setCharOn (int i) {
        CharOn = i;
    }

    public int getChar1 () {
        return Char1;
    }

    public int getChar2 () {
        return Char2;
    }

    public int getRunDisplay () {
        return runDisplay;
    }

    public void setRunDisplay (int i) {
        runDisplay = i;
    }

    public void setSelectedSave (int i) {
        selectedSave = i;
    }

}
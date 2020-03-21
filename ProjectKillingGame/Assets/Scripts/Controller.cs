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
    public GameObject nameboxText;
    public TextBox textbox;
    public UIManager UIManager;
    public Load LoadMenu;
    public Novel novel;
    public inspection inspection;
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
        if (novel.getCurrentLine () == -1) {
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
        DisplayCh1 ();
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
        if (novel.savedIndex == 1 && novel.getCurrentLine () == -1) {
            UIManager.changeBG ("Prologue");
            currentBG = 1;
        }
        UIManager.textboxAppear ();
        runDisplay = 0;
    }

    void DisplayCh1 () {
        runDisplay = 1;
        if (novel.getCurrentLine () == 8) {
            UIManager.charAppear (2);
        }

        if (novel.getCurrentLine () == 7 && Ch1VisualsLoaded == false) {
            Ch1VisualsLoaded = true;
            // Change Namebox
            changeNameBoxText ("Sabrina");
            // Jump to 2nd BG
            UIManager.changeBG ("SabrinasRoom");

            currentBG = 2;
            CharOn = 1;
        }

        if (novel.getCurrentLine () == 16 && GameObject.Find ("sink") == null && gameMode == "reading") {
            //enable inspection mode
            gameMode = "inspection";
            //disable writing visuals
            UIManager.charDisappear (2);
            stopWriting ();
            UIManager.textboxDisappear ();

            GameObject.Find ("InspectionElements").GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
            GameObject.Find ("TutorialPanel").GetComponent<RectTransform> ().Translate (new Vector2 (675f, 0f));
            GameObject.Find ("CloseTutorialPanel").GetComponent<Button> ().onClick.AddListener (() => {
                GameObject.Find ("TutorialPanel").GetComponent<RectTransform> ().Translate (new Vector2 (-675f, 0f));
                inspection.instObject ("sink", 300f, -50f, 80f, 70f, 1, 1); //sink
                inspection.instObject ("toilet", 300f, -200f, 80f, 70f); //toillet
                inspection.instObject ("bed", -220f, -180f, 240f, 120f); //bed
                inspection.instObject ("shaft", -30f, 225f, 80f, 50f, 3, 2, 1); //ventilation shaft
                inspection.instStoryObject ("door", 220f, -30f, 120f, 320f); //door
                inspection.instObject ("screen", 90f, 60f, 100f, 100f, 2, 0); //screen
                inspection.instObject ("lights", 150f, 200f, 250f, 70f); //lights
                inspection.instObject ("chair", -20f, -100f, 80f, 90f); //chair
                inspection.disableNavForInspectionElems();
            });
        }

        runDisplay = 0;
    }

    public void loadSabrinaRoom () {
        UIManager.changeBG ("SabrinasRoom");
        UIManager.charDisplay ("none");
        gameMode = "inspection";
        stopWriting ();
        UIManager.textboxDisappear ();
        GameObject.Find ("InspectionElements").GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }

    IEnumerator DisplayCh1_1 () {
        while (GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().GetAlpha () != 1f) {
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
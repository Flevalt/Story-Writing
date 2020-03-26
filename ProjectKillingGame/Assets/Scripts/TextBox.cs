using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public GameObject nextpage;
    public GameObject nameboxText;
    public GameObject namebox;
    public Novel novel;
    public Items items;
    GameObject textwr;
    public Controller controller;
    public TitleWrite titlewrite;
    public Inspection inspection;
    public Skip skip;
    private float f = 0.02f; //write delay, aka textspeed
    public int txtWriterNr = 1;
    private bool eventWait = false; // only true in the case of a sound/event to prevent normal read chapter from working in that case 
    private bool eventCall = false; //turns true when an eventDisplay call is ready and turns false again after the eventDisplay was executed.
    private bool eventCalled = true; //alternates with eventCall. Only 1 of both can be true at all times.

    public UIManager UIManager;

    private Color thoughtColor;

    private void Awake () {
        nextpage.GetComponent<Button> ().enabled = false;

        textwr = Instantiate (new GameObject ()); //instance of textwriter
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite> (); //add functionality to textwriter instance

        //Color initializations
        ColorUtility.TryParseHtmlString ("#FFC1C1", out thoughtColor);
    }

    void Update () {

        if (textwr == null) {
            textwr = GameObject.Find ("textwriter(Inst)" + txtWriterNr);
        }

        // Only attempt writing at all if controller hasn't disabled it
        if (Equals (controller.gameMode, "reading")) {
            if (controller.enableWrite == true) {

                Debug.Log ("line " + novel.currentLine + "/" + novel.currentCh.Length + " ch " + novel.currentChapter);

                startNextChapterVisuals (); // loads visuals of next chapter if current chapter ends.
                read (); // checks whether to load events or write text.

            } else if (controller.enableWrite == false) {
                inspectionRead (); // checks whether to load inspection writing
            }
        }
    }

    /**
     * Called only when Text is being displayed during Inspection Mode.
     */
    private void inspectionRead () {
        if (Input.GetKeyDown ("space")) {
            inspection.startInspectionMode ();

            //Textwrite
            if (inspection.inspectionType == 0) {
                inspection.showInspectionElements ();
            }
            // Item Found
            else if (inspection.inspectionType == 1) {
                UIManager.openItemObtainedWindow ();
                GameObject.Find ("ItemObtainedWindow").GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 19f);
                GameObject.Find ("YouFound").GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
                StartCoroutine (UIManager.itemObtainedAppear (inspection.itemId));

                inspection.changeListener (inspection.lastClicked);
                //TODO: perhaps change 2nd param to int by creating ints for each change in inspection for each object

            }
            // Coins Found
            else if (inspection.inspectionType == 2) {
                GameObject.Find ("CoinsObtained").GetComponent<RectTransform> ().localPosition = new Vector2 (200f, 150f);
                StartCoroutine (coinObtainedAppear (controller.coinAmount));
                inspection.changeListener (inspection.lastClicked);
            }
            // Decision Time
            else if (inspection.inspectionType == 3) {
                UIManager.openDecisionWindow ();
            }
        }
    }

    /**
     * Loads visuals of next chapter if the end of current chapter is reached.
     */
    private void startNextChapterVisuals () {

        if (Input.GetKeyDown ("space") && controller.getRunDisplay () == 0 && novel.currentLine == -1 && novel.currentChapter == 0) {
            Debug.Log ("Ch0 on");
            controller.startCh0 ();
        }
        // DisplayCh1 can be called multiple times parallely without... && controller.getRunDisplay() == 0 
        else if ((Input.GetKeyDown ("space") || (skip.autoOn == true && skip.skipOn == false) || (skip.skipOn == true && skip.autoOn == false)) &&
            Equals (novel.currentLine, novel.currentCh.Length - 1)) {

            if (novel.currentChapter == 0) {
                Debug.Log ("Ch1 on");
                controller.startCh1 ();
            } else if (novel.currentChapter == 1) {
                Debug.Log ("Ch1_1_1 on");
                controller.startCh1_1_1 ();
            } else if (novel.currentChapter == 1.1f) {
                Debug.Log ("Ch1_2 on");
                controller.startCh1_2 ();
            } else if (novel.currentChapter == 1.2f) {
                Debug.Log ("Ch1_3 on");
                controller.startCh1_3 ();
            }
        }
    }

    /**
     * Calls a writing function depending on whether auto, skip or normal reading is active.
     */
    private void read () {
        if (skip.skipOn == false && skip.autoOn == true && textwr.GetComponent<TextWrite> ().run == false) {
            //Auto-call
            Debug.Log ("case 1");
            nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
            GameObject textwr = restartTextWriter ();
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite> ();
            textwr.GetComponent<TextWrite> ().setF (f);
            textwr.GetComponent<TextWrite> ().attemptAuto ();
            changeTextColor (); //change color for thought-text
        } else if (skip.skipOn == true && skip.autoOn == false && (textwr.GetComponent<TextWrite> ().run == false || textwr.GetComponent<TextWrite> ().skippin == false)) {
            //Skip-call only if skippin isn't currently running for the 2nd time
            Debug.Log ("case 2");
            nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
            GameObject textwr = restartTextWriter ();
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite> ();
            textwr.GetComponent<TextWrite> ().setF (f);
            textwr.GetComponent<TextWrite> ().attemptSkip ();
            changeTextColor (); //change color for thought-text
        } else if (Input.GetKeyDown ("space") &&
            skip.skipOn == skip.autoOn && eventWait == false) {
            //Normal Read-Chapter-call
            handleEventsAndRead ();
        }
    }

    /**
     * Checks whether events need to be run or text needs to be written.
     */
    private void handleEventsAndRead () {
        //checks if eventlines are reached.
        if (eventCalled == true) {
            if (novel.currentChapter == 1.1f) {
                switch (novel.currentLine) {
                    case 3:
                    case 4:
                    case 6:
                    case 8:
                    case 12:
                    case 14:
                        eventCall = true;
                        eventCalled = false;
                        break;
                }
            }
        } else {
            eventCall = false;
        }

        //prevents reading if eventline is reached and plays event instead.
        if (eventCall == true) {
            //displays cutscene
            if (novel.currentLine == 3 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (0));
            } else if (novel.currentLine == 4 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (1));
            } else if (novel.currentLine == 6 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (2));
            } else if (novel.currentLine == 8 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (3));
            } else if (novel.currentLine == 12 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (4));
            } else if (novel.currentLine == 14 && novel.currentChapter == 1.1f) {
                StartCoroutine (displayEvent (5));
            }
            eventCall = false;
        } else { //otherwise reads normally if no event is currently ongoing

            Debug.Log ("case 3: Normal Read");
            nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0.00f);

            GameObject textwr = restartTextWriter ();
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite> ();
            textwr.GetComponent<TextWrite> ().setF (f);
            textwr.GetComponent<TextWrite> ().attemptWriting ();

            //change namebox & chars
            changeNameBoxAndChars ();
            //change color for thought-text
            changeTextColor ();
            eventCalled = true; //reset checking for eventDisplay
        }
    }

    /**
     * Changes NameBox and Char Visuals for the TextBox depending on the current line.
     */
    private void changeNameBoxAndChars () {
        if (novel.currentChapter == 1.1f) {
            switch (novel.currentLine) {
                //line n
                case 15:
                case 17:
                    nameboxText.GetComponent<Text> ().text = "???";
                    UIManager.charDisplay ("both");
                    GameObject.Find ("Char2").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
                    UIManager.switchChar (1, "base1");
                    break;
                case 16: //Sabrina talks
                case 18:
                    sabrinaTalks ();
                    break;
                case 19:
                    UIManager.charDisplay ("2");
                    GameObject.Find ("BlackFog2").GetComponent<RectTransform> ().localPosition = new Vector3 (0f, 0f, 0f);
                    break;
                case 20:
                    UIManager.charDisplay ("2");
                    GameObject.Find ("BlackFog2").GetComponent<RectTransform> ().localPosition = new Vector3 (1000f, 0f, 0f);
                    break;
            }
        } else if (novel.currentChapter == 1.2f) {
            switch (novel.currentLine) {
                case 0: //Director talks
                case 5:
                case 9:
                case 14:
                    shironekoTalks ();
                    break;
                case 4:
                case 8:
                case 13:
                case 24:
                    sabrinaTalks ();
                    break;
            }
        }
    }

    private void shironekoTalks () {
        GameObject.Find ("Char2").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
        GameObject.Find ("Char1").GetComponent<CanvasRenderer> ().SetAlpha (1f);
        nameboxText.GetComponent<Text> ().text = "Shineko";
    }

    private void sabrinaTalks () {
        if (controller.getCharOn () == 2) {
            GameObject.Find ("Char2").GetComponent<CanvasRenderer> ().SetAlpha (1f);
            GameObject.Find ("Char1").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
            nameboxText.GetComponent<Text> ().text = "Sabrina";
        } else {
            GameObject.Find ("Char2").GetComponent<CanvasRenderer> ().SetAlpha (1f);
            nameboxText.GetComponent<Text> ().text = "Sabrina";
        }
    }

    /**
     * Changes color of the textbox's text depending on the current line.
     */
    private void changeTextColor () {
        gameObject.GetComponent<TextMeshProUGUI> ().color = Color.white;

        if (novel.currentChapter == 1) {
            switch (novel.currentLine) {
                case 1:
                case 4:
                case 6:
                    changeColor (thoughtColor);
                    break;
            }
        } else if (novel.currentChapter == 1.1f) {
            switch (novel.currentLine) {
                case 6:
                case 11:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    changeColor (thoughtColor);
                    break;
            }
        }
    }

    private void changeColor (Color color) {
        gameObject.GetComponent<TextMeshProUGUI> ().color = color;
        gameObject.GetComponent<TextMeshProUGUI> ().fontSharedMaterial.EnableKeyword ("UNDERLAY_ON");
        gameObject.GetComponent<TextMeshProUGUI> ().fontSharedMaterial.SetFloat ("_GlowPower", 0.5f);
    }

    // Displays different events depending on switch case including play sound, display title, pauses etc.
    IEnumerator displayEvent (int eventId) {
        eventWait = true;
        switch (eventId) {
            case 0:
                // Door Pound before 30 minutes later
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("SFX3").GetComponent<AudioSource> ().Play ();
                yield return new WaitForSeconds (2f);
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
                break;
            case 1:
                //...30 minutes later...
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                UIManager.charDisplay ("none");
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                GetComponent<TextBox> ().txtWriterNr = 1;
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("BlackFog").GetComponent<CanvasRenderer> ().SetAlpha (0.8f);
                GameObject.Find ("BlackFog").GetComponent<Transform> ().localPosition = new Vector3 (0f, 0f, 0f);

                titlewrite.fadeInTitle ("...30 minutes later...", Color.white, 0.052f); //fade in title: 30 minutes later

                GameObject.Find ("SFX3").GetComponent<AudioSource> ().Play ();
                yield return new WaitForSeconds (2f);
                titlewrite.fadeOutTitle (); //fade out title
                GameObject.Find ("SFX3").GetComponent<AudioSource> ().Play ();
                yield return new WaitForSeconds (2f);
                GameObject.Find ("BlackFog").GetComponent<Transform> ().localPosition = new Vector3 (1000f, 0f, 0f);
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
                UIManager.charDisplay ("2");
                break;
            case 2:
                // ...2 hours later...
                UIManager.charDisplay ("none");
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                GetComponent<TextBox> ().txtWriterNr = 1;
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("BlackFog").GetComponent<CanvasRenderer> ().SetAlpha (0.8f);
                GameObject.Find ("BlackFog").GetComponent<Transform> ().localPosition = new Vector3 (0f, 0f, 0f);

                titlewrite.fadeInTitle ("...2 hours later...", Color.white, 0.052f); //fade in title: 2 hours later

                yield return new WaitForSeconds (2f);
                titlewrite.fadeOutTitle (); //fade out title
                yield return new WaitForSeconds (2f);
                GameObject.Find ("BlackFog").GetComponent<Transform> ().localPosition = new Vector3 (1000f, 0f, 0f);
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
                UIManager.charDisplay ("2");
                break;
            case 3:
                // Stranger appears & rattles at door
                UIManager.charDisplay ("none");
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                GetComponent<TextBox> ().txtWriterNr = 1;
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("SFX4").GetComponent<AudioSource> ().Play ();
                yield return new WaitForSeconds (2.1f);
                UIManager.charDisplay ("2");
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
                break;
            case 4:
                // Director appears
                UIManager.textboxDisappear ();
                UIManager.charDisplay ("none");
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                GetComponent<TextBox> ().txtWriterNr = 1;
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("SFX1").GetComponent<AudioSource> ().Play ();
                UIManager.changeBG ("directorAppear1");
                yield return new WaitForSeconds (2f);
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
                GameObject.Find ("SFX1").GetComponent<AudioSource> ().Play ();
                UIManager.changeBG ("directorAppear2");
                yield return new WaitForSeconds (2f);
                for (int i = 0; i < 5; i++) {
                    UIManager.textboxAppear ();
                }
                UIManager.switchChar (1, "director");
                UIManager.charDisplay ("both");
                nameboxText.GetComponent<Text> ().text = "???";
                GameObject.Find ("Char2").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
                GameObject.Find ("Char1").GetComponent<CanvasRenderer> ().SetAlpha (1f);
                nextpage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
                break;
            case 5:
                //Director disappears
                //textwr.SetActive (false);
                Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
                GetComponent<TextBox> ().txtWriterNr = 1;
                gameObject.GetComponent<TextMeshProUGUI> ().text = "";
                GameObject.Find ("SFX1").GetComponent<AudioSource> ().Play ();
                UIManager.changeBG ("SabrinasRoom");
                inspection.startInspectionMode ();
                inspection.changeListener ("1_1_1_door");
                break;
        }
        eventWait = false;
    }

    private GameObject restartTextWriter () {
        Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
        //textwr.SetActive (true);
        GameObject textwr = Instantiate (new GameObject ());

        return textwr;
    }

    //external call of play sound
    public void playSFX () {
        StartCoroutine (playSound ());
    }

    //Plays sound during text
    IEnumerator playSound () {
        eventWait = true;
        GameObject.Find ("SFX5").GetComponent<AudioSource> ().Play ();
        yield return new WaitForSeconds (0.5f);
        eventWait = false;
    }

    IEnumerator coinObtainedAppear (int coinAmount) {

        GameObject.Find ("CoinNr").GetComponent<Text> ().text = coinAmount.ToString ();

        for (int k = 0; k < 5; k++) {
            GameObject.Find ("CoinsObtained").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinsObtained").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
            GameObject.Find ("CoinsFound").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinsFound").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
            GameObject.Find ("CoinNr").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinNr").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
            yield return new WaitForSeconds (0.08f);
        }

        yield return new WaitForSeconds (1f);

        for (int k = 0; k < 5; k++) {
            GameObject.Find ("CoinsObtained").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinsObtained").GetComponent<CanvasRenderer> ().GetAlpha () - 0.2f);
            GameObject.Find ("CoinsFound").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinsFound").GetComponent<CanvasRenderer> ().GetAlpha () - 0.2f);
            GameObject.Find ("CoinNr").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("CoinNr").GetComponent<CanvasRenderer> ().GetAlpha () - 0.2f);
            yield return new WaitForSeconds (0.08f);
        }

        GameObject.Find ("CoinsObtained").GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);

        inspection.InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }

    public void createTextWriterInst () {
        if (GameObject.Find ("textwriter(Inst)" + txtWriterNr) != null) {
            Destroy (GameObject.Find ("textwriter(Inst)" + txtWriterNr));
        }
        GameObject textwr = Instantiate (new GameObject ());
        //textwr.SetActive (true);
        txtWriterNr += 1;
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite> ();
        textwr.GetComponent<TextWrite> ().setF (f);
    }

    public float getF () {
        return f;
    }

    public void setF (float fl) {
        f = fl;
        GameObject.Find ("textwriter(Inst)" + txtWriterNr).GetComponent<TextWrite> ().setF (fl);
    }

}
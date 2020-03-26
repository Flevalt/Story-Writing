using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Responsible for instantiation of Inspection Objects and their Listeners.
 */
public class Inspection : MonoBehaviour {

    public Sprite img;
    public Items items;
    public Novel novel;
    public Controller controller;
    public TextBox textbox;
    private TextWrite tw;
    public int inspectionType; //0 = text, 1 = itemFound, 2 = coinsFound, 3 = decision.
    public string lastClicked; //Name of the last inspection object clicked
    public int itemId; //item id for itemfound

    public GameObject InspectionElements;

    public int itemFound1; //the nr represents the itemID, the value if true=1 or false=0
    public int itemFound2;
    public int itemFound3;
    public int itemFound4;
    public int itemFound5;
    public int itemFound6;
    public int itemFound7;
    public int itemFound8;
    public int itemFound9;
    public int itemFound10;
    public int itemFound11;
    public int itemFound12;
    public int itemFound13;
    public int itemFound14;
    public int itemFound15;
    public int itemFound16;
    public int itemFound17;
    public int itemFound18;
    public int itemFound19;
    public int itemFound20;
    public int itemFound21;
    public int itemFound22;
    public int itemFound23;
    public int itemFound24;
    public int itemFound25;
    public int itemFound26;
    public int itemFound27;
    public int itemFound28;
    public int itemFound29;
    public int itemFound30;
    public int itemFound31;
    public int itemFound32;

    public UIManager UIManager;

    private void Start () {
        //Hide Decision & ItemObtained Windows
        UIManager.closeDecisionWindow ();
        UIManager.closeItemObtainedWindow ();

        hideInspectionElements ();
    }

    /**
     * CONSTRUCTORS for Inspection Elements
     */
    //Create inspection element that switches to Story Mode
    public void instStoryObject (string instanceName, float xPos, float yPos, float width, float height) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        addStoryListener (instanceName, iO, "2", 0);
    }

    //Create inspection element for Decision
    public void instDecisionObject (string instanceName, float xPos, float yPos, float width, float height, int itemObjectID, int itemID, int decisionId) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        addDecisionListener (iO.GetComponent<Button> (), itemObjectID, instanceName, itemID, decisionId);
    }

    //Create inspection element that finds item
    // @objectID = inspection object; 
    // @itemObjectID = inspection object that drops items;
    // @itemID = the item that drops;
    public void instItemFoundObject (string instanceName, float xPos, float yPos, float width, float height, int itemObjectID, int itemID) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        addItemFoundListener (iO.GetComponent<Button> (), itemObjectID, instanceName, itemID);
    }

    //instantiate pure Text
    public void instObject (string instanceName, float xPos, float yPos, float width, float height) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        iO.GetComponent<Button> ().onClick.AddListener (() => {
            lastClicked = instanceName;
            inspectionType = 0;
            displayText (instanceName);
        });
    }

    /**
     * Instantiates a new inspection Element. 
     * Used in other functions to create the element before enriching it with a listener.
     */
    public GameObject createInspectionElem (string instanceName, float xPos, float yPos, float width, float height) {
        GameObject iOO = new GameObject (instanceName.ToString ());
        GameObject iO = Instantiate (iOO);
        iO.name = instanceName;
        Destroy (iOO);

        Image im = iO.AddComponent<Image> ();
        im.sprite = img;

        iO.transform.SetParent (InspectionElements.transform, false);

        iO.GetComponent<RectTransform> ().localPosition = new Vector2 (xPos, yPos);
        iO.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, height);

        Button btn = iO.AddComponent<Button> ();
        Navigation navigation = btn.navigation;
        navigation.mode = Navigation.Mode.None;

        iO.AddComponent<PolygonCollider2D> ();
        iO.AddComponent<MouseHover> ();

        return iO;
    }

    /**
     * Stops inspection elements from listening to keyboard input.
     */
    public void disableNavForInspectionElems () {
        foreach (Button elem in InspectionElements.GetComponentsInChildren<Button> ()) {
            Navigation nav = new Navigation ();
            nav.mode = Navigation.Mode.None;
            elem.navigation = nav;
        }
    }

    /**
     * LISTENERS for inspection elements
     */
    // Story progresses
    private void addStoryListener (string instanceName, GameObject iO, string charDisplay, int currentLine) {
        iO.GetComponent<Button> ().onClick.AddListener (() => {
            lastClicked = instanceName;

            hideInspectionElements ();

            controller.gameMode = "reading";
            UIManager.charDisplay (charDisplay);
            controller.enableWrite = true;
            novel.currentLine = currentLine;
            textbox.GetComponent<TextMeshProUGUI> ().text = novel.getChapter (novel.currentChapter) [novel.currentLine];
            controller.startCh1_1 ();
            GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().SetAlpha (0f);
            textbox.playSFX ();
        });
    }
    // A decision window pops up
    private void addDecisionListener (Button btn, int itemFoundId, string instanceName, int itemID, int decisionID) {
        switch (itemFoundId) {
            case 1:
                break;
            case 2:
            case 3:
                btn.onClick.AddListener (() => {
                    lastClicked = instanceName;
                    itemId = itemID;
                    inspectionType = 3; //decision
                    controller.decision = 1; //for switch case in TextBox
                    displayText (instanceName);
                });
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }
    // An item is found on click
    private void addItemFoundListener (Button btn, int itemFoundId, string instanceName, int itemID) {
        switch (itemFoundId) {
            case 1:
                btn.onClick.AddListener (() => {
                    lastClicked = instanceName;
                    itemId = itemID;
                    inspectionType = 1; //item found
                    displayText (instanceName);
                    itemFound1 = 1; //if true, listener has to be changed on click
                });
                break;
            case 2:
                btn.onClick.AddListener (() => {
                    lastClicked = instanceName;
                    itemId = itemID;
                    controller.coinAmount = 1;
                    inspectionType = 2; //coin found
                    displayText (instanceName);
                    itemFound2 = 1;
                });
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    //change listener if the inspection element had more than just text
    public void changeListener (string instanceName) {
        GameObject.Find (instanceName).GetComponent<Button> ().onClick.RemoveAllListeners ();
        switch (instanceName) {
            case "1_1_1_sink": // change sink text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("1_1_1_sinkRepeat");
                });
                break;
            case "1_1_1_door": // change door(id=5) to move into Round1, Phase1 Hall.
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (2000f, 0f);
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 3;
                    GameObject.Find ("SFX7").GetComponent<AudioSource> ().Play ();
                    GameObject.Find ("MainCam").GetComponent<Transform> ().localPosition = new Vector3 (0f, -10f, -10f);
                    controller.gameMode = "corridorWalk";
                });
                break;
            case "1_1_1_screen": //change screen text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("1_1_1_screenRepeat");
                });
                break;
            case "1_1_1_shaft": //change shaft text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("1_1_1_shaftRepeat");
                });
                break;
        }
    }

    /**
     * Creates the various instances of inspection elements for all the possible rooms.
     * TODO: @param id - selects the elements to instantiate.
     */
    public void createInspectionElements () {
        instStoryObject ("1_1_1_door", 220f, -30f, 120f, 320f); //door

        instDecisionObject ("1_1_1_shaft", -30f, 225f, 80f, 50f, 3, 2, 1); //ventilation shaft
        instItemFoundObject ("1_1_1_screen", 90f, 60f, 100f, 100f, 2, 0); //screen
        instItemFoundObject ("1_1_1_sink", 300f, -50f, 80f, 70f, 1, 1); //sink

        instObject ("1_1_1_toilet", 300f, -200f, 80f, 70f); //toilet
        instObject ("1_1_1_bed", -220f, -180f, 240f, 120f); //bed
        instObject ("1_1_1_lights", 150f, 200f, 250f, 70f); //lights
        instObject ("1_1_1_chair", -20f, -100f, 80f, 90f); //chair
    }
    /**
     * Starts Inspection Mode.
     */
    public void startInspectionMode () {
        UIManager.charDisplay ("none");
        UIManager.textboxDisappear ();
        controller.gameMode = "inspection";
        controller.stopWriting ();
        InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
        Destroy (GameObject.Find ("textwriter(Inst)" + textbox.txtWriterNr));
        textbox.GetComponent<TextBox> ().txtWriterNr = 1;

        /*
        gameObject.GetComponent<TextMeshProUGUI> ().text = "";
        GameObject.Find ("UI_Panel").GetComponent<CanvasRenderer> ().SetAlpha (0f);
        namebox.GetComponent<CanvasRenderer> ().SetAlpha (0f);
        nextpage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
        nameboxText.GetComponent<CanvasRenderer> ().SetAlpha (0f);
        */
    }

    public void showInspectionElements () {
        InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }

    public void hideInspectionElements () {
        InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
    }

    /**
     * Opens the textbox and writes the text associated with the inspection element.
     */
    public void displayText (string id) {
        float tempChapter = novel.currentChapter;
        hideInspectionElements ();
        GameObject.Find ("Mouse1").GetComponent<MouseAnimator> ().changeMouse (1);

        UIManager.textboxAppear ();
        UIManager.charDisplay ("2");
        if (id.Contains ("1_1_1")) {
            novel.currentChapter = 1.11f;
        }

        switch (id) {
            case "1_1_1_sink":
                novel.currentLine = 0;
                break;
            case "1_1_1_toilet":
                novel.currentLine = 1;
                break;
            case "1_1_1_bed":
                novel.currentLine = 2;
                break;
            case "1_1_1_shaft":
                novel.currentLine = 3;
                break;
            case "1_1_1_door":
                novel.currentLine = 4;
                break;
            case "1_1_1_screen":
                novel.currentLine = 5;
                break;
            case "1_1_1_lights":
                novel.currentLine = 6;
                break;
            case "1_1_1_chair":
                novel.currentLine = 7;
                break;
            case "1_1_1_sinkRepeat":
                novel.currentLine = 8;
                break;
            case "1_1_1_screenRepeat":
                novel.currentLine = 9;
                break;
            case "1_1_1_shaftRepeat":
                novel.currentLine = 10;
                break;
        }
        controller.gameMode = "reading";
        textbox.createTextWriterInst ();
        tw = GameObject.Find ("textwriter(Inst)" + textbox.txtWriterNr).GetComponent<TextWrite> ();
        tw.attemptInspectionWriting ();
        // resets the chapter to its original before clicking on the inspection element.
        novel.currentChapter = tempChapter;
    }

}
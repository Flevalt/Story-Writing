using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Manages the Logic for inspection Items on the screen during Inspection Mode.
 */
public class inspection : MonoBehaviour {

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

        InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
    }

    /**
     * CONSTRUCTORS for Inspection Elements
     */
    //Create inspection element that switches to Story Mode
    public void instStoryObject (string instanceName, float xPos, float yPos, float width, float height) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        addStoryListener (instanceName, iO, "2", 18);
    }

    //Create inspection element for Decision
    public void instObject (string instanceName, float xPos, float yPos, float width, float height, int itemObjectID, int itemID, int decisionId) {
        GameObject iO = createInspectionElem (instanceName, xPos, yPos, width, height);
        addDecisionListener (iO.GetComponent<Button> (), itemObjectID, instanceName, itemID, decisionId);
    }

    //Create inspection element that finds item
    // @objectID = inspection object; 
    // @itemObjectID = inspection object that drops items;
    // @itemID = the item that drops;
    public void instObject (string instanceName, float xPos, float yPos, float width, float height, int itemObjectID, int itemID) {
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

            InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);

            controller.gameMode = "reading";
            UIManager.charDisplay (charDisplay);
            controller.enableWrite = true;
            novel.setCurrentLine (currentLine);
            textbox.GetComponent<TextMeshProUGUI> ().text = novel.getCurrentCh (novel.savedIndex) [novel.getCurrentLine ()];
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
            case "sink": // change sink text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("sinkRepeat");
                });
                break;
            case "door": // change door(id=5) to move into Round1, Phase1 Hall.
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (2000f, 0f);
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 3;
                    GameObject.Find ("SFX7").GetComponent<AudioSource> ().Play ();
                    GameObject.Find ("MainCam").GetComponent<Transform> ().localPosition = new Vector3 (0f, -10f, -10f);
                    controller.gameMode = "corridorWalk";
                });
                break;
            case "screen": //change screen text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("screenRepeat");
                });
                break;
            case "shaft": //change shaft text
                GameObject.Find (instanceName).GetComponent<Button> ().onClick.AddListener (() => {
                    lastClicked = instanceName; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText ("shaftRepeat");
                });
                break;
        }
    }

    /**
     * Opens the textbox and writes the text associated with the inspection element.
     */
    public void displayText (string id) {
        InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
        GameObject.Find ("Mouse1").GetComponent<MouseAnimator> ().changeMouse (1);

        UIManager.textboxAppear ();
        UIManager.charDisplay ("2");
        switch (id) {
            case "sink":
                novel.setCurrentLine (74);
                break;
            case "toilet":
                novel.setCurrentLine (75);
                break;
            case "bed":
                novel.setCurrentLine (76);
                break;
            case "shaft":
                novel.setCurrentLine (77);
                break;
            case "door":
                novel.setCurrentLine (78);
                break;
            case "screen":
                novel.setCurrentLine (79);
                break;
            case "lights":
                novel.setCurrentLine (80);
                break;
            case "chair":
                novel.setCurrentLine (81);
                break;
            case "sinkRepeat":
                novel.setCurrentLine (82);
                break;
            case "screenRepeat":
                novel.setCurrentLine (83);
                break;
            case "shaftRepeat":
                novel.setCurrentLine (84);
                break;
        }
        controller.gameMode = "reading";
        textbox.createTextWriterInst ();
        tw = GameObject.Find ("textwriter(Inst)" + textbox.txtWriterNr).GetComponent<TextWrite> ();
        tw.attemptInspectionWriting ();
    }

}
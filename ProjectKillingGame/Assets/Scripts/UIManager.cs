using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles all UI Elements EXCEPT those of the title.
 */

public class UIManager : MonoBehaviour {

    // INSPECTION Elements
    public Inspection inspection;
    // Decision Window
    public GameObject DecisionWindow, ChoiceBtn1, ChoiceBtn2;
    // Decision Window Text
    public GameObject ChoiceTitleText, ChoiceBtn1Text, ChoiceBtn2Text;
    // Item Obtained Window
    public GameObject ItemObtainedWindow, YouFound, YouFoundText;
    public Image FoundItem;

    public Controller controller;
    public Novel novel;
    public Camera MainCam;
    public GameObject Background;
    public TextBox textbox;
    public GameObject UIPanel;

    public GameObject GameMenu;
    public GameObject Compendium;
    public GameObject StatusOverview;
    public GameObject Map;
    public GameObject Settings;

    Color erase = new Color (0f, 0f, 0f, 1f); //color to erase alpha

    void Start () {
        if (novel.currentLine != -1) { //While not at beginning of Chapter
            UIPanel.GetComponent<CanvasRenderer> ().SetAlpha (1f);
            charDisplay ("both");
        } else { //While at beginning of chapter
            charDisplay ("none");
            changeBG ("Page1");
            textboxDisappear ();
        }
    }

    void Update () {
        handleEscInput ();
    }

    //Escape Btn Input
    void handleEscInput () {
        if (controller.gameMode == "inspection" && Input.GetKeyDown ("escape")) {
            if (getCompOpen () == true) {
                hideCompendium ();
            } else if (getSettingsOpen () == true) {
                hideSettings ();
            } else if (getMapOpen () == true) {
                hideMap ();
            } else if (getStatOpen () == true) {
                hideStatus ();
            } else if (menuOpen == false) {
                showGameMenu ();
            } else if (menuOpen == true && quit.getQuitting () == false) {
                hideGameMenu ();
            } else if (menuOpen == true && quit.getQuitting () == true) {
                quit.setQuitting (false);
            }
        }
    }

    /**
     * BACKGROUND IMAGE
     */
    public void changeBG (string imgName) {

        if (imgName == ("Prologue")) {
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/Page1");
            controller.currentBG = 1;
        }
        if (imgName == ("SabrinasRoom")) {
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/t3");
            controller.currentBG = 2;
        }
        if (imgName == ("directorAppear1")) {
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/ton");
            controller.currentBG = 2;
        }
        if (imgName == ("directorAppear2")) {
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/ton2");
            controller.currentBG = 3;
        }
        if (imgName == ("directorAppear3")) { // not in use yet
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/ton3");
            controller.currentBG = 4;
        }
        if (imgName == ("Black")) { //not in use yet
            Background.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("BGs/FadeInOut");
            controller.currentBG = 5;
        }
    }
    public void hideBackground () {
        //Background.GetComponent<SpriteRenderer> ().color = Background.GetComponent<SpriteRenderer> ().color - erase;
    }
    public void showBackground () {
        //Background.GetComponent<SpriteRenderer> ().color = Background.GetComponent<SpriteRenderer> ().color + erase;
    }

    /**
     * DECISION WINDOW
     */
    public void confirmationWindow () {
        openDecisionWindow ();
        changeDecisionText ("Confirm Save?", "Yes", "No");
        ChoiceBtn1.GetComponent<Button> ().onClick.AddListener (() => { controller.LoadMenu.loadData (controller.selectedSave); closeDecisionWindow (); });
        ChoiceBtn2.GetComponent<Button> ().onClick.AddListener (() => { closeDecisionWindow (); });
    }
    public void openDecisionWindow () {
        DecisionWindow.SetActive (true);
        hideDecisionWindow ();
        DecisionWindow.GetComponentInChildren<RectTransform> ().localPosition = new Vector2 (0f, 0f);
        StartCoroutine (fadeInDecisionWindow ());
    }
    public void closeDecisionWindow () {
        DecisionWindow.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
        DecisionWindow.SetActive (false);
    }
    public void hideDecisionWindow () {
        foreach (CanvasRenderer canvas in DecisionWindow.GetComponentsInChildren<CanvasRenderer> ()) {
            canvas.SetAlpha (0f);
        }
    }
    /**
     * Fades in Decision Window.
     */
    public IEnumerator fadeInDecisionWindow () {
        //Choose decision based on id
        switch (controller.decision) {
            case 1: //weapon-pick decision
                changeDecisionText ("Pick up the gun?", "Let's take it.", "Leave it there.");
                // Change listeners
                ChoiceBtn1.GetComponent<Button> ().onClick.AddListener (() => {
                    inspection.itemFound3 = 1;
                    closeDecisionWindow ();
                    inspection.changeListener (inspection.lastClicked);
                    openItemObtainedWindow ();
                });
                ChoiceBtn2.GetComponent<Button> ().onClick.AddListener (() => {
                    inspection.itemFound3 = 0;
                    closeDecisionWindow ();
                    inspection.InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
                });
                break;
        }

        for (int k = 0; k < 5; k++) {
            foreach (CanvasRenderer canvas in DecisionWindow.GetComponentsInChildren<CanvasRenderer> ()) {
                canvas.SetAlpha (canvas.GetAlpha () + 0.2f);
            }
            yield return new WaitForSeconds (0.08f);
        }
    }
    /**
     * Changes the text for the Decision Window.
     */
    public void changeDecisionText (string title, string choice1, string choice2) {
        ChoiceTitleText.GetComponent<Text> ().text = title; //"Leave the Game?"
        ChoiceBtn1Text.GetComponent<Text> ().text = choice1; //"Return to Main Menu."
        ChoiceBtn2Text.GetComponent<Text> ().text = choice2; //"Return to Desktop."
    }

    /**
     * ITEM OBTAINED WINDOW
     */
    public void openItemObtainedWindow () {
        ItemObtainedWindow.SetActive (true);
        ItemObtainedWindow.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 19f);
        StartCoroutine (itemObtainedAppear (inspection.itemId));
    }
    public IEnumerator itemObtainedAppear (int itemID) {

        //Change Item image & text before displaying
        FoundItem.sprite = textbox.items.getItemSprite (itemID);
        YouFoundText.GetComponent<Text> ().text = "You found " + textbox.items.getItemName (itemID);

        YouFoundText.GetComponent<CanvasRenderer> ().SetAlpha (1f);
        //Display elements in the following order
        for (int k = 0; k < 5; k++) {
            foreach (CanvasRenderer canvas in ItemObtainedWindow.GetComponentsInChildren<CanvasRenderer> ()) {
                canvas.SetAlpha (canvas.GetAlpha () + 0.2f);
            }
            yield return new WaitForSeconds (0.08f);
        }

        yield return new WaitForSeconds (2f);

        for (int k = 0; k < 5; k++) {
            foreach (CanvasRenderer canvas in ItemObtainedWindow.GetComponentsInChildren<CanvasRenderer> ()) {
                canvas.SetAlpha (canvas.GetAlpha () - 0.2f);
                foreach (CanvasRenderer canvas2 in canvas.GetComponentsInChildren<CanvasRenderer> ()) {
                    canvas2.SetAlpha (canvas2.GetAlpha () - 0.2f);
                }
            }
            yield return new WaitForSeconds (0.08f);
        }
        ItemObtainedWindow.SetActive (false);
        ItemObtainedWindow.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
        inspection.InspectionElements.GetComponent<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }
    // Called during the beginning of the game in the Inspection class
    public void closeItemObtainedWindow () {
        ItemObtainedWindow.SetActive (false);
        ItemObtainedWindow.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
    }

    /**
     * TEXTBOX
     *   
     * Textbox and all it's elements appear.
     */
    public void textboxAppear () {
        //Get UI_Panel's and all children's CanvasRenderer
        foreach (CanvasRenderer renderer in UIPanel.GetComponentsInChildren<CanvasRenderer> ()) {
            renderer.SetAlpha (1f);
            //Get children's children's CanvasRenderer
            renderer.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1f);
        }
        foreach (Button btn in UIPanel.GetComponentsInChildren<Button> ()) {
            btn.enabled = true;
        }
    }

    /**
     * Textbox and all it's elements disappear.
     */
    public void textboxDisappear () {
        foreach (Button btn in UIPanel.GetComponentsInChildren<Button> ()) {
            btn.enabled = false;
        }
        foreach (CanvasRenderer renderer in UIPanel.GetComponentsInChildren<CanvasRenderer> ()) {
            renderer.SetAlpha (0f);
            renderer.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0f);
        }
    }

    // TextBox's Character Slots
    public void charDisplay (string charOn) {
        // 0 = 1on,2off, 1 = 1off,2on, 2 = 1on, 2on, 3 = 1off, 2off
        switch (charOn) {
            case "1":
                charAppear (1);
                charDisappear (2);
                controller.CharOn = 0;
                break;
            case "2":
                charDisappear (1);
                charAppear (2);
                controller.CharOn = 1;
                break;
            case "both":
                charAppear (1);
                charAppear (2);
                controller.CharOn = 2;
                break;
            case "none":
                charDisappear (1);
                charDisappear (2);
                controller.CharOn = 3;
                break;
        }
    }
    public void charAppear (int i) {
        GameObject.Find ("Char" + i).GetComponent<CanvasRenderer> ().SetAlpha (1f);
    }
    public void charDisappear (int i) {
        GameObject.Find ("Char" + i).GetComponent<CanvasRenderer> ().SetAlpha (0f);
    }

    public void charOutgrey (int i) {
        // Char Outgrey while present but not talking
        GameObject.Find ("Char" + i).GetComponent<CanvasRenderer> ().SetColor (new Color (0.2f, 0.2f, 0.2f));
    }

    /**
     * 
     * @param slot - Slot 1 (left) and 2 (right) for the characters.
     * @param imgName - filename of the character's image.
     */
    public void switchChar (int slot, string imgName) {
        GameObject.Find ("Char" + slot).GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Sprites/" + imgName);
    }

    /**
    |----------------------------------|
    |---------GameMenu Window----------|
    |----------------------------------|
    */
    public Quit quit; // Logic for closing the game.
    private bool compendiumOpen = false;
    private bool statusOpen = false;
    private bool mapOpen = false;
    private bool settingsOpen = false;
    private bool menuOpen = false; // GameMenu Window open/closed

    public void showGameMenu () {
        menuOpen = true;
        GameMenu.GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
    }
    public void hideGameMenu () {
        GameMenu.GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        menuOpen = false;
    }

    public void showCompendium () {
        Compendium.GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        compendiumOpen = true;
    }
    public void hideCompendium () {
        Compendium.GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setCompOpen (false);
    }

    public void showStatus () {
        StatusOverview.GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        statusOpen = true;
    }
    public void hideStatus () {
        StatusOverview.GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setStatOpen (false);
    }

    public void showMap () {
        Map.GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        mapOpen = true;
    }
    public void hideMap () {
        Map.GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setMapOpen (false);
    }

    public void showSettings () {
        Settings.GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        settingsOpen = true;
    }
    public void hideSettings () {
        Settings.GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setSettingsOpen (false);
    }

    public bool getCompOpen () {
        return compendiumOpen;
    }

    public bool getStatOpen () {
        return statusOpen;
    }

    public bool getMapOpen () {
        return mapOpen;
    }

    public bool getSettingsOpen () {
        return settingsOpen;
    }

    public void setSettingsOpen (bool i) {
        settingsOpen = i;
    }

    public void setCompOpen (bool i) {
        compendiumOpen = i;
    }

    public void setStatOpen (bool i) {
        statusOpen = i;
    }

    public void setMapOpen (bool i) {
        mapOpen = (i);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles all UI Elements EXCEPT those of the title.
 */

public class UIManager : MonoBehaviour {
    public GameObject DecisionBox;
    public GameObject Pick1, Pick2;

    public GameObject ItemObtainedBox;
    public Controller controller;
    public Novel novel;
    public Camera MainCam;
    public GameObject Background;

    public GameObject UIPanel;

    Color erase = new Color (0f, 0f, 0f, 1f); //color to erase alpha

    void Start () {
        if (novel.getCurrentLine () != -1) { //While not at beginning of Chapter
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
        Pick1.GetComponent<Button> ().onClick.AddListener (() => { controller.LoadMenu.loadData (controller.selectedSave); closeDecisionWindow (); });
        Pick2.GetComponent<Button> ().onClick.AddListener (() => { closeDecisionWindow (); });
    }
    public void openDecisionWindow () {
        DecisionBox.SetActive (true);
        DecisionBox.GetComponentInChildren<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }
    public void closeDecisionWindow () {
        DecisionBox.GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
        DecisionBox.SetActive (false);
    }
    /**
     * Changes the text for the Decision Window.
     */
    public void changeDecisionText (string title, string choice1, string choice2) {
        GameObject.Find ("2DecisionText").GetComponent<Text> ().text = title; //"Leave the Game?"
        GameObject.Find ("choice1").GetComponent<Text> ().text = choice1; //"Return to Main Menu."
        GameObject.Find ("choice2").GetComponent<Text> ().text = choice2; //"Return to Desktop."
    }
    // ItemObtained Window
    public void openItemObtainedWindow () {
        ItemObtainedBox.SetActive (true);
    }
    public void closeItemObtainedWindow () {
        ItemObtainedBox.SetActive (false);
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

    public void CharOutgrey (int i) {
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
        GameObject.Find ("GameMenu").GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
    }
    public void hideGameMenu () {
        GameObject.Find ("GameMenu").GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        menuOpen = false;
    }

    public void showCompendium () {
        GameObject.Find ("Compendium").GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        compendiumOpen = true;
    }
    public void hideCompendium () {
        GameObject.Find ("Compendium").GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setCompOpen (false);
    }

    public void showStatus () {
        GameObject.Find ("StatusOverview").GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        statusOpen = true;
    }
    public void hideStatus () {
        GameObject.Find ("StatusOverview").GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setStatOpen (false);
    }

    public void showMap () {
        GameObject.Find ("Map").GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        mapOpen = true;
    }
    public void hideMap () {
        GameObject.Find ("Map").GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
        setMapOpen (false);
    }

    public void showSettings () {
        GameObject.Find ("Settings").GetComponentInChildren<RectTransform> ().position = new Vector2 (340f, 250f);
        settingsOpen = true;
    }
    public void hideSettings () {
        GameObject.Find ("Settings").GetComponentInChildren<RectTransform> ().position = new Vector2 (2000f, 0f);
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
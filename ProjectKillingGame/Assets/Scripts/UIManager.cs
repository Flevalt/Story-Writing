using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject DecisionBox;
    public GameObject ItemObtainedBox;
    public Controller Controller;

    void Update () {
        //Menu Controls
        if (Controller.gameMode == 1 && Input.GetKeyDown ("escape")) {

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

    // Decision Window
    public void openDecisionWindow () {
        DecisionBox.SetActive (true);
        GameObject.Find ("DecisionWindow").GetComponentInChildren<RectTransform> ().localPosition = new Vector2 (0f, 0f);
    }
    public void closeDecisionWindow () {
        GameObject.Find ("DecisionWindow").GetComponent<RectTransform> ().localPosition = new Vector2 (1000f, 0f);
        DecisionBox.SetActive (false);
    }
    /**
    * Changes the text for the Decision Window.
    */
    public void changeDecisionText(string title, string choice1, string choice2) {
        GameObject.Find ("2DecisionText").GetComponent<Text> ().text = "Leave the Game?";
        GameObject.Find ("choice1").GetComponent<Text> ().text = "Return to Main Menu.";
        GameObject.Find ("choice2").GetComponent<Text> ().text = "Return to Desktop.";
    }
    // ItemObtained Window
    public void openItemObtainedWindow () {
        ItemObtainedBox.SetActive (true);
    }
    public void closeItemObtainedWindow () {
        ItemObtainedBox.SetActive (false);
    }

    // TextBox's NameBox
    public void showNameBox () {
        GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().SetAlpha (1f);
        GameObject.Find ("NameBoxText").GetComponent<CanvasRenderer> ().SetAlpha (1f);
    }
    public void hideNameBox () {
        GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().SetAlpha (0f);
        GameObject.Find ("NameBoxText").GetComponent<CanvasRenderer> ().SetAlpha (0f);
    }

    //TextBox
    public void textboxAppear () {
        GameObject.Find ("UI_Panel").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("UI_Panel").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("Skip").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("Skip").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("Auto").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("Auto").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("SpeedUp").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("SpeedUp").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("SpeedDown").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("SpeedDown").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("Load").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("Load").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("Menu").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("Menu").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);

        GameObject.Find ("T1").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T1").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("T2").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T2").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("T3").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T3").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("T4").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T4").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("T6").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T6").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("T7").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("T7").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);
        GameObject.Find ("NameBoxText").GetComponent<CanvasRenderer> ().SetAlpha (GameObject.Find ("NameBoxText").GetComponent<CanvasRenderer> ().GetAlpha () + 0.2f);

        GameObject.Find ("NameBox").GetComponent<Button> ().enabled = true;
        GameObject.Find ("Skip").GetComponent<Button> ().enabled = true;
        GameObject.Find ("Auto").GetComponent<Button> ().enabled = true;
        GameObject.Find ("SpeedUp").GetComponent<Button> ().enabled = true;
        GameObject.Find ("SpeedDown").GetComponent<Button> ().enabled = true;
        GameObject.Find ("Load").GetComponent<Button> ().enabled = true;
        GameObject.Find ("Menu").GetComponent<Button> ().enabled = true;
        GameObject.Find ("NameBox").GetComponent<Button> ().enabled = true;
    }

    public void textboxDisappear () {
        GameObject.Find ("NameBox").GetComponent<Button> ().enabled = false;
        GameObject.Find ("Skip").GetComponent<Button> ().enabled = false;
        GameObject.Find ("Auto").GetComponent<Button> ().enabled = false;
        GameObject.Find ("SpeedUp").GetComponent<Button> ().enabled = false;
        GameObject.Find ("SpeedDown").GetComponent<Button> ().enabled = false;
        GameObject.Find ("Load").GetComponent<Button> ().enabled = false;
        GameObject.Find ("Menu").GetComponent<Button> ().enabled = false;
        GameObject.Find ("NameBox").GetComponent<Button> ().enabled = false;

        GameObject.Find ("UI_Panel").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("Skip").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("Auto").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("SpeedUp").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("SpeedDown").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("Load").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("Menu").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("NextPage").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T1").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T2").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T3").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T4").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T6").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("T7").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("NameBox").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
        GameObject.Find ("NameBoxText").GetComponent<CanvasRenderer> ().SetAlpha (0.00f);
    }

    // TextBox's Character Slots
    public void charDisplay (int charOn) {
        // 0 = 1on,2off, 1 = 1off,2on, 2 = 1on, 2on, 3 = 1off, 2off
        switch (charOn) {
            case 0:
                charAppear (1);
                charDisappear (2);
                Controller.CharOn = 0;
                break;
            case 1:
                charDisappear (1);
                charAppear (2);
                Controller.CharOn = 1;
                break;
            case 2:
                charAppear (1);
                charAppear (2);
                Controller.CharOn = 2;
                break;
            case 3:
                charDisappear (1);
                charDisappear (2);
                Controller.CharOn = 3;
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
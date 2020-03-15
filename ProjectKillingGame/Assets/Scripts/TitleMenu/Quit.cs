using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

    private bool quitting = false; // Quit-Choice Window currently open/closed.
    public UIManager UIManager;

    public void closeApp () {
        Application.Quit ();
    }

    public void decisionAppear () {
        UIManager.openDecisionWindow();

        //Decision text
        UIManager.changeDecisionText("Leave the Game?", "Return to Main Menu.", "Return to Desktop.");
        quitting = true;

        //Choice 1
        GameObject.Find ("Pick1").GetComponent<Button> ().onClick.AddListener (() => {
            SceneManager.LoadScene (0);
        });
        //Choice 2
        GameObject.Find ("Pick2").GetComponent<Button> ().onClick.AddListener (() => {
            Application.Quit ();
        });

    }

    public bool getQuitting () {
        return quitting;
    }

    public void setQuitting (bool b) {
        quitting = b;
    }

}
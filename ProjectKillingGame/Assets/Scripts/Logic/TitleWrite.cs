using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleWrite : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0.0f); //Make Title invisible by default
    }

    /**
     * Instantly hides title.
     */
    public void hideTitle () {
        StopAllCoroutines (); // stops ongoing fade in
        gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0f);
        gameObject.SetActive (false);
    }

    /**
     * Slowly fades title out.
     */
    public void fadeOutTitle () {
        StartCoroutine (fadeOutTitleStep ());
    }

    /**
     * Slowly fades title in.
     * Note: setActive(true) instantly lets object appear...but without it, the title's Hitbox is in the way...
     */
    public void fadeInTitle (string titleName, Color colorId, float speed) {
        gameObject.SetActive (true);
        gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0f);
        setTitle (titleName, colorId);
        StartCoroutine (fadeInTitleStep (speed));
    }

    //-------------------------------------------
    //Sub-Functions of this class's main methods.
    //-------------------------------------------
    IEnumerator fadeOutTitleStep () {
        while (gameObject.GetComponent<CanvasRenderer> ().GetAlpha () > 0f) {
            gameObject.GetComponent<CanvasRenderer> ().SetAlpha (gameObject.GetComponent<CanvasRenderer> ().GetAlpha () - 0.052f);
            yield return new WaitForSeconds (0.08f);
        }
    }

    IEnumerator fadeInTitleStep (float speed) {
        while (gameObject.GetComponent<CanvasRenderer> ().GetAlpha () < 1f) {
            gameObject.GetComponent<CanvasRenderer> ().SetAlpha (gameObject.GetComponent<CanvasRenderer> ().GetAlpha () + speed);
            yield return new WaitForSeconds (0.08f);
        }
    }

    /**
     * Sets the text and text-color for the title to be displayed.
     */
    private void setTitle (string title, Color color) {
        gameObject.GetComponent<Text> ().color = color;
        gameObject.GetComponent<Text> ().text = title;

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

    private bool quitting = false;

	public void closeApp()
    {
        Application.Quit();
    }

    public void decisionAppear()
    {
            GameObject.Find("2Decision").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("Pick1").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("Pick2").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("2DecisionTextPanel").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("choice1").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("choice2").GetComponent<CanvasRenderer>().SetAlpha(1f);
            GameObject.Find("2DecisionText").GetComponent<CanvasRenderer>().SetAlpha(1f);
        GameObject.Find("2Decision").GetComponentInChildren<RectTransform>().localPosition = new Vector2(0f, 0f);


        //Decision text
        GameObject.Find("2DecisionText").GetComponent<Text>().text = "Leave the Game?";
        GameObject.Find("choice1").GetComponent<Text>().text = "Return to Main Menu.";
        GameObject.Find("choice2").GetComponent<Text>().text = "Return to Desktop.";
        quitting = true;

        //Choice 1
        GameObject.Find("Pick1").GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
        //Choice 2
        GameObject.Find("Pick2").GetComponent<Button>().onClick.AddListener(() => {
            Application.Quit();
        });

    }

    public bool getQuitting()
    {
        return quitting;
    }

    public void setQuitting(bool b)
    {
        quitting = b;
    }

}

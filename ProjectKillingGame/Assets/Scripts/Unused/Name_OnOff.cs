using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name_OnOff : MonoBehaviour {

    public Button ObjectToDisable;
    private string NameToSwitch;

	// Enable or Disable in Start()
	void Start ()
    {
        ObjectToDisable = GameObject.Find("NameBox").GetComponent<Button>();
    }

    // Enable interaction
    void Enable ()
    {
        ObjectToDisable.interactable = true;
        GameObject.Find("NameBox").SetActive(true);
    }
    // Disable interaction
    void Disable ()
    {
        ObjectToDisable.interactable = false;
        GameObject.Find("NameBox").SetActive(false);
    }

    public void switchName(string name)
    {
        GameObject.Find("T8").GetComponent<Text>().text = name; // change name on display
        NameToSwitch = name; // save name in the class
    }

    public string getName()
    {
        return NameToSwitch;
    }
}

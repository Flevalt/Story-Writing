using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name_OnOff : MonoBehaviour {

    public Button ObjectToDisable;

	// Enable or Disable in Start()
	void Start ()
    {
        ObjectToDisable = GameObject.Find("NameBox").GetComponent<UnityEngine.UI.Button>();
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
}

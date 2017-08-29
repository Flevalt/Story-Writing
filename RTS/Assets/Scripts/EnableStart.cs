using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableStart : MonoBehaviour {

    public Button GO;

    private void Start()
    {
        GO = GameObject.Find("StartButton").GetComponent<UnityEngine.UI.Button>();
    }

    // Use this for initialization
    public void Enable()
    {
        GO.interactable = true;
    }

    public void Disable()
    {
        GO.interactable = false;
    }

}

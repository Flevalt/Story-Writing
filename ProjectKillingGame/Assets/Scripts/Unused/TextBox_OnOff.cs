using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox_OnOff : MonoBehaviour {

    // Enable interaction
    void Enable()
    {
        GameObject.Find("TextBox_Panel").SetActive(true);
    }
    // Disable interaction
    void Disable()
    {
        GameObject.Find("TextBox_Panel").SetActive(false);
    }
}

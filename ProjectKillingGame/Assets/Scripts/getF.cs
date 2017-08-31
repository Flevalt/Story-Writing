using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getF : MonoBehaviour {

    public TextWrite textwr;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("TextSpeed").GetComponent<Text>().text = textwr.getF().ToString();
    }
}

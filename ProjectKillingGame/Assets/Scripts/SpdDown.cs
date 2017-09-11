using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdDown : MonoBehaviour {

    private TextBox writespd;

    private void Awake()
    {
        writespd = GameObject.Find("Textbox").GetComponent<TextBox>();
    }

    public void SpeedDown()
    {
        if(writespd.getF() > 0.14f){ }
        else {
            writespd.setF(writespd.getF() + 0.01f);
        }
    }
}

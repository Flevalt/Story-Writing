using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdUp : MonoBehaviour {

    private TextBox writespd;

    private void Awake()
    {
        writespd = GameObject.Find("Textbox").GetComponent<TextBox>();
    }

    public void SpeedUp()
    {
        if (writespd.getF() == 0) { }
        else
        {
            writespd.setF(writespd.getF() - 0.01f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdDown : MonoBehaviour {

    public TextWrite writespd;

    public void SpeedDown()
    {
        if(writespd.getF() > 0.14f){ }
        else {
            writespd.setF(writespd.getF() + 0.01f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdUp : MonoBehaviour {

    public TextWrite writespd;

	public void SpeedUp()
    {
        if (writespd.getF() == 0) { }
        else
        {
            writespd.setF(writespd.getF() - 0.01f);
        }
    }
}

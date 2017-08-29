using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXContainer : MonoBehaviour {

    private static SFXContainer instance = null;

    //Constructor
    public static SFXContainer Instance
    {
        get { return instance; }
    }

    //Play BGM at Awake and check on change
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

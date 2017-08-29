using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMContainer : MonoBehaviour
{
    private static BGMContainer instance = null;

    //Constructor
    public static BGMContainer Instance
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
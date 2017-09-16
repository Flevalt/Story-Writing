using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour
{
    private static SoundContainer instance = null;

    //Constructor
    public static SoundContainer Instance
    {
        get { return instance; }
    }

    //Play BGM at Awake and check on change
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}

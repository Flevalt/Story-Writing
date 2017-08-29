using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class AudioControl : MonoBehaviour {

    private static AudioControl instance = null;

    public AudioSource[] bgms;
    public AudioSource[] sfx;

    //Constructor
    public static AudioControl Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Masterkey");
            bgms = GameObject.Find("BGMContainer").GetComponentsInChildren<AudioSource>();
            sfx = GameObject.Find("SFXContainer").GetComponentsInChildren<AudioSource>();

            for (int i = 0; i < bgms.Length; i++)
            {
                bgms[i].volume = PlayerPrefs.GetFloat("BGMkey");
            }
            for (int i = 0; i < sfx.Length; i++)
            {
                sfx[i].volume = PlayerPrefs.GetFloat("SFXkey");
            }

            bgms[0].Play();
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

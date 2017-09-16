using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

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
            Destroy(gameObject);
            return;
        }
        else
        {
            // AudioListener.volume = PlayerPrefs.GetFloat("Masterkey");
            bgms = GameObject.Find("BGMContainer").GetComponentsInChildren<AudioSource>();
            sfx = GameObject.Find("SoundContainer").GetComponentsInChildren<AudioSource>();

            if (PlayerPrefs.HasKey("BGMkey"))
            {
                for (int i = 0; i < bgms.Length; i++)
                {
                    bgms[i].volume = PlayerPrefs.GetFloat("BGMkey");
                }
            }
            else bgms[0].volume = 1f;

            if (PlayerPrefs.HasKey("SFXkey"))
            {
                for (int i = 0; i < sfx.Length; i++)
                {
                    sfx[i].volume = PlayerPrefs.GetFloat("SFXkey");
                }
            }
            else sfx[0].volume = 1f;

            bgms[0].Play();
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}

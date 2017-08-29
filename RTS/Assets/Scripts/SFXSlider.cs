using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{

    public Slider sfxSlider;
    public AudioSource[] sfx;

    // Use this for initialization
    void Awake ()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXkey");
        sfx = GameObject.Find("SFXContainer").GetComponentsInChildren<AudioSource>();
    }

    private void OnGUI()
    {
        PlayerPrefs.SetFloat("SFXkey", sfxSlider.value);
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].volume = PlayerPrefs.GetFloat("BGMkey");
        }
    }
}

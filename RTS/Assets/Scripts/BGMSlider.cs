using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{

    public Slider bgmSlider;
    public AudioSource[] bgms;

    // Use this for initialization
    void Awake()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGMkey");
        bgms = GameObject.Find("BGMContainer").GetComponentsInChildren<AudioSource>();
    }

    private void OnGUI()
    {
        PlayerPrefs.SetFloat("BGMkey", bgmSlider.value);
        for (int i = 0; i < bgms.Length; i++)
        {
            bgms[i].volume = PlayerPrefs.GetFloat("BGMkey");
        }
    }
}
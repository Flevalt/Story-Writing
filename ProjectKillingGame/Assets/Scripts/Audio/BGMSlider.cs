using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{

    public Slider bgmSlider;
    public AudioSource[] bgm;

    // Use this for initialization
    void Awake()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGMkey");
        bgm = GameObject.Find("BGMContainer").GetComponentsInChildren<AudioSource>();
    }

    private void OnGUI()
    {
        PlayerPrefs.SetFloat("BGMkey", bgmSlider.value);
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].volume = PlayerPrefs.GetFloat("BGMkey");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSlider : MonoBehaviour
{

    public Slider masterSlider;
    public AudioSource master;

    // Use this for initialization
    void Awake()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Masterkey");
    }

    private void OnGUI()
    {
        PlayerPrefs.SetFloat("Masterkey", masterSlider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("Masterkey");
    }
}

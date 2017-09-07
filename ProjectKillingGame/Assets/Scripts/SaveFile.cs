using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile : MonoBehaviour {

    private float a;
    private int b;
    private int c;
    private int d;
    private int e;
    private int f;
    List<float> saveData;

    void Awake()
    {
        saveData = new List<float>();
        saveData.Add(a);
    }

    public void setAll(int i)
    {
            a = PlayerPrefs.GetFloat("textspeed" + i);
            b = PlayerPrefs.GetInt("currentBG" + i);
            c = PlayerPrefs.GetInt("Char1" + i);
            d = PlayerPrefs.GetInt("Char2" + i);
            e = PlayerPrefs.GetInt("currentIndex" + i);
            f = PlayerPrefs.GetInt("currentLine" + i);
    }

    public GameObject getSaveFile()
    {
        return GameObject.Find("SaveFile");
    }
}

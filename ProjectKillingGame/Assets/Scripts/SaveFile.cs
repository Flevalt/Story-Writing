using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile : MonoBehaviour {

    public int savefileindex;
    private float a;
    private int b;
    private int c;
    private int d;
    private int e;
    private int f;
    private int g;
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
            e = PlayerPrefs.GetInt("CharOn" + i);
            f = PlayerPrefs.GetInt("currentIndex" + i);
            g = PlayerPrefs.GetInt("currentLine" + i);
            savefileindex = i;
    }

    public GameObject getSaveFile()
    {
        return GameObject.Find("SaveFile");
    }
}

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
    private int h;
    private int ha;
    private int hb;
    private int hc;
    private int hd;
    private int he;
    private int hf;
    private int hg;
    private int hh;
    private int hi;
    private int hj;
    private int hk;
    private int hl;
    private int hm;
    private int hn;
    private int ho;
    private int hp;
    private int hq;
    private int hr;
    private int hs;
    private int ht;
    private int hu;
    private int hv;
    private int hw;
    private int hx;
    private int hy;
    private int hz;
    private int haa;
    private int hab;
    private int hac;
    private int had;
    private int hae;

    public void setAll(int i)
    {
            a = PlayerPrefs.GetFloat("textspeed" + i);
            b = PlayerPrefs.GetInt("currentBG" + i);
            c = PlayerPrefs.GetInt("Char1" + i);
            d = PlayerPrefs.GetInt("Char2" + i);
            e = PlayerPrefs.GetInt("CharOn" + i);
            f = PlayerPrefs.GetInt("currentIndex" + i);
            g = PlayerPrefs.GetInt("currentLine" + i);
            h = PlayerPrefs.GetInt("itemFound1" + i);
        ha = PlayerPrefs.GetInt("itemFound2" + i);
        hb = PlayerPrefs.GetInt("itemFound3" + i);
        hc = PlayerPrefs.GetInt("itemFound4" + i);
        hd = PlayerPrefs.GetInt("itemFound5" + i);
        he = PlayerPrefs.GetInt("itemFound6" + i);
        hf = PlayerPrefs.GetInt("itemFound7" + i);
        hg = PlayerPrefs.GetInt("itemFound8" + i);
        hh = PlayerPrefs.GetInt("itemFound9" + i);
        hi = PlayerPrefs.GetInt("itemFound10" + i);
        hj = PlayerPrefs.GetInt("itemFound11" + i);
        hk = PlayerPrefs.GetInt("itemFound12" + i);
        hl = PlayerPrefs.GetInt("itemFound13" + i);
        hm = PlayerPrefs.GetInt("itemFound14" + i);
        hn = PlayerPrefs.GetInt("itemFound15" + i);
        ho = PlayerPrefs.GetInt("itemFound16" + i);
        hp = PlayerPrefs.GetInt("itemFound17" + i);
        hq = PlayerPrefs.GetInt("itemFound18" + i);
        hr = PlayerPrefs.GetInt("itemFound19" + i);
        hs = PlayerPrefs.GetInt("itemFound20" + i);
        ht = PlayerPrefs.GetInt("itemFound21" + i);
        hu = PlayerPrefs.GetInt("itemFound22" + i);
        hv = PlayerPrefs.GetInt("itemFound23" + i);
        hw = PlayerPrefs.GetInt("itemFound24" + i);
        hx = PlayerPrefs.GetInt("itemFound25" + i);
        hy = PlayerPrefs.GetInt("itemFound26" + i);
        hz = PlayerPrefs.GetInt("itemFound27" + i);
        haa = PlayerPrefs.GetInt("itemFound28" + i);
        hab = PlayerPrefs.GetInt("itemFound29" + i);
        hac = PlayerPrefs.GetInt("itemFound30" + i);
        had = PlayerPrefs.GetInt("itemFound31" + i);
        hae = PlayerPrefs.GetInt("itemFound32" + i);
        savefileindex = i;
    }

    public GameObject getSaveFile()
    {
        return GameObject.Find("SaveFile");
    }
}

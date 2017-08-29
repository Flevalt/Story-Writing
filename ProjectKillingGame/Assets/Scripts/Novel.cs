using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novel : MonoBehaviour {

    public string[] currentCh; //all text of the current chapter for loading by external classes
    public int savedIndex; //current chapter saved as integer
    private string[] Ch1 = new string[10];
    private string[] Ch2 = new string[10];
    private string[] Ch3 = new string[10];
    private string[] Ch4 = new string[10];
    private string[] Ch5 = new string[10];

    // Use this for initialization
    void Start ()
    {
        currentCh = getCurrentCh(savedIndex);
    }

    public Novel getNovel()
    {
        return this;
    }

    public string[] getCurrentCh(int index)
    {
        if(index == 1)
        {
            Ch1[0] = "Although this dwarf resembles our home planet, it is a far more hostile place.";
            Ch1[1] = "and line2";
            Ch1[2] = "or line3";
            Ch1[3] = "why line4";
            Ch1[4] = "hmm line5";
            Ch1[5] = "well line6";
            Ch1[6] = "sure, line7";

            return Ch1;
        }
        else if(index == 2)
        {
            Ch2[0] = "line1 of chapter 2";
            Ch2[1] = "and line2";
            Ch2[2] = "or line3";
            Ch2[3] = "why line4";
            Ch2[4] = "hmm line5";
            Ch2[5] = "well line6";
            Ch2[6] = "sure, line7";

            return Ch2;
        }

        else
        {
            Ch5[0] = "line1 of chapter 3";
            Ch5[1] = "and line2";
            Ch5[2] = "or line3";
            Ch5[3] = "why line4";
            Ch5[4] = "hmm line5";
            Ch5[5] = "well line6";
            Ch5[6] = "sure, line7";

            return Ch5;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novel : MonoBehaviour {

    public string[] currentCh; //all text of the current chapter for loading by external classes
    public int savedIndex = 1; //current chapter saved as integer
    private int currentLine = -1;
    private string[] Ch1 = new string[200];
    private string[] Ch2 = new string[200];
    private string[] Ch3 = new string[200];
    private string[] Ch4 = new string[200];
    private string[] Ch5 = new string[200];

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
            Ch1[0] = "Earth. \nThe only planet with the right conditions for life to form, that we know of.";
            Ch1[1] = "Right now, there are billions of people living on this dwarf of a planet among dozens of other lifeforms. All of them living out their fleeting lives.";
            Ch1[2] = "It didn't always used to look like this.";
            Ch1[3] = "The land we step on now used to be lava flowing around the surface. With close to no oxygen, it was nothing but a hostile molten sphere.";
            Ch1[4] = "And even now, that place is still there. A molten core, deep down into the Earth.";
            Ch1[5] = "In a way, you could say the Earth we know is nothing but a facade. Beautiful and lively on the outside, but its fiery and dangerous inner self still dormant inside.";
            Ch1[6] = "It makes you wonder for how long a place like Earth can last. And sometimes I wonder...";
            Ch1[7] = "...how many people can a small planet like Earth take?";
            Ch1[8] = "";
            Ch1[9] = "";
            Ch1[10] = "";
            Ch1[11] = "";
            Ch1[12] = "";
            Ch1[13] = "";
            Ch1[14] = "";
            Ch1[15] = "";
            Ch1[16] = "";
            Ch1[17] = "";

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

    public int getCurrentLine()
    {
        return currentLine;
    }

    public void setCurrentLine(int i)
    {
        currentLine = i;
    }

}

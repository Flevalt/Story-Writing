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

    private void Awake()
    {
        currentCh = getCurrentCh(savedIndex);
    }

    public string[] getCurrentCh(int index)
    {
        if(index == 1)
        {
            // currL[0] = -1
            Ch1[0] = "Earth. \nThe only planet with the right conditions for life to form, that we know of.";
            // currL[1] = 0
            Ch1[1] = "Right now, there are billions of people living on this dwarf of a planet among dozens of other lifeforms. All of them living out their fleeting lives.";
            Ch1[2] = "It didn't always used to look like this.";
            Ch1[3] = "The land we step on now used to be lava flowing around the surface. With close to no oxygen, it was nothing but a hostile molten sphere.";
            Ch1[4] = "And even now, that place is still there. A molten core, deep down into the Earth.";
            Ch1[5] = "In a way, you could say the Earth we know is nothing but a facade. Beautiful and lively on the outside, but its fiery and dangerous inner self still dormant inside.";
            Ch1[6] = "It makes you wonder for how long a place like Earth can act as a home to living creatures. And sometimes I wonder...";
            Ch1[7] = "...how many people can a small planet like Earth take?";
            Ch1[8] = "uhn...";
            Ch1[9] = "nh...";
            Ch1[10] = "ah...!!";
            Ch1[11] = "This place...where am I?";
            Ch1[12] = "My body feels like I was hit by a truck.";
            Ch1[13] = "I don't like the look of this. And this room gives off an eerie vibe.\n I'd better check outside.";
            Ch1[14] = "";
            Ch1[15] = "Nnnngh...";
            Ch1[16] = "What the heck? It won't open.";
            Ch1[17] = "Help! The door is stuck!";
            Ch1[18] = "Hello? Someone, heeelp!";
            Ch1[18] = "Help! Can someone hear me ?";
            Ch1[19] = "What do I do?";
            Ch1[20] = "What if nobody comes? I'll be locked in here forever?";
            Ch1[21] = "But there is no food in this room. I'll starve before anything else. At least there is a toillet";
            Ch1[22] = "Isn't there any way to escape? Let's see...";
            Ch1[23] = "This room doesn't seem to have any windows.";
            Ch1[24] = "Maybe there is something I can use to break the door?";
            Ch1[25] = "Good morning, chosen one.";
            Ch1[26] = "I am Ms. X, consider me to be your guide on this trial that lies before you.";
            Ch1[27] = "Please bear in mind that there are no input devices on your side of the screen, and as such, I am unable to hear or see you and can therefore not answer any questions.";
            Ch1[28] = "You have been chosen to partake in project Arbel, to save the world. My congratulations.";
            Ch1[29] = "Save the world?";
            Ch1[30] = "Your decisions in this project will decide mankind's fate. Let us hope that I made the right choice in picking you for the job.";
            Ch1[31] = "I will explain how this is going to proceed. Please listen carefully, as I will not repeat myself.";
            Ch1[32] = "You are currently locked up in your assigned room. Do not panic. This is part of the project procedure, for your own safety.";
            Ch1[33] = "What is she saying?";
            Ch1[34] = "You will find in your room: A bed, a toillet, a sink and a weapon.";
            Ch1[35] = "There is no weapon in this room. Perhaps this message is intended for someone else?";
            Ch1[36] = "It is highly recommended that you pick up the weapon in your room. But it is not a necessity for what you are about to face.";
            Ch1[37] = "Outside this room is a place refered to as Hall.";
            Ch1[38] = "The Hall is a megastructure that drives normal humans insane once they near it. Do not trust your senses while in the Hall. Also beware, as armed demons roam freely inside the Hall.";
            Ch1[39] = "D-Demons?...haha. Wait, did she say they are armed?";
            Ch1[40] = "As long as you are within your assigned room, you are safe from harm. But this will not do.";
            Ch1[41] = "Once a day at 12pm, starting from now, I will unlock this door for 8 hours.";
            Ch1[42] = "There are many other doors inside the Hall, some of which lead to places of interest. These doors will henceforth be refered to as hellgates.";
            Ch1[43] = "Only one hellgate will unlock per day. Your goal, every day, should be to search for this unlocked hellgate inside The Hall.";
            Ch1[44] = "Once your room is unlocked, it will allow you to move freely inside The Hall to search for that hellgate. It is recommended to run away from monsters in the Hall on sight.";
            Ch1[45] = "Once you make it through a hellgate, you will be faced with a trial.";
            Ch1[46] = "Your main objective in this project is to overcome all trials in this place. Then, and only then, will the exit door unlock.";
            Ch1[47] = "Keep in mind that 8 hours after your door was unlocked, I will lock the door again until 12 pm the next day. There will be no way to open the door from either side for the next 16 hours from that moment on.";
            Ch1[48] = "It is now 12 pm sharp. I will unlock the doors in accordance with the procedures.";
            Ch1[49] = "Best of luck to you, chosen one.";
            Ch1[50] = "...";
            Ch1[51] = "The heck?";
            Ch1[52] = "And they even forgot to put the weapon in the room. What kind of half-assed project is this ? World saving my ass.";
            Ch1[53] = "At least the door is open now. I'm getting out of here.";
            Ch1[54] = "";

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
        else if (index == 3)
        {
            Ch5[0] = "line1 of chapter 3";
            Ch5[1] = "and line2";
            Ch5[2] = "or line3";
            Ch5[3] = "why line4";
            Ch5[4] = "hmm line5";
            Ch5[5] = "well line6";
            Ch5[6] = "sure, line7";

            return Ch3;
        }
        else if (index == 4)
        {
            Ch5[0] = "line1 of chapter 3";
            Ch5[1] = "and line2";
            Ch5[2] = "or line3";
            Ch5[3] = "why line4";
            Ch5[4] = "hmm line5";
            Ch5[5] = "well line6";
            Ch5[6] = "sure, line7";

            return Ch4;
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

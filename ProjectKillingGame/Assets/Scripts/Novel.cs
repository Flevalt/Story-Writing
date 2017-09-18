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
            // Start of Prologue/Ch0
            Ch1[0] = "Earth. \nThe only planet with the right conditions for life to form, that we know of.";
            Ch1[1] = "Right now, there are billions of people living on this dwarf of a planet among dozens of other lifeforms. All of them living out their fleeting lives.";
            Ch1[2] = "It didn't always used to look like this.";
            Ch1[3] = "The land we step on now used to be lava flowing around the surface. With close to no oxygen, it was nothing but a hostile molten sphere.";
            Ch1[4] = "And even now, that place is still there. A molten core, deep down into the Earth.";
            Ch1[5] = "In a way, you could say the Earth we know is nothing but a facade. Beautiful and lively on the outside, but its fiery and dangerous inner self still dormant inside.";
            Ch1[6] = "It makes you wonder for how long a place like Earth can act as a home to living creatures. And sometimes I wonder...";
            Ch1[7] = "...how many people can a small planet like Earth take?";
            Ch1[8] = "uhn..."; //Start of Ch1
            Ch1[9] = "I woke up in a room I had never seen before. I was rather cold. \nOr no...the room temperature in general was low."; //
            Ch1[10] = "nh...";
            Ch1[11] = "ah...!!";
            Ch1[12] = "As my eyes jumped between the room, I started to think that this room looked strangely empty and sterile."; //
            Ch1[13] = "This place...where am I?";
            Ch1[14] = "A sudden rush of pain overcame me. I started to notice that my entire body ached."; //
            Ch1[15] = "Oww..! My body feels like I was hit by a truck.";
            Ch1[16] = "I don't like the look of this. And this room gives off an eerie vibe. I'd better check outside."; 
            Ch1[17] = ""; //=>Inspection Mode

            Ch1[18] = "Nnnngh..."; //=>Story Mode //door sound
            Ch1[19] = "What the heck? It won't open.";
            //Pound against door sound 1
            Ch1[20] = "Help! The door is stuck!";
            Ch1[21] = "Hello? Someone, help!";
            //Pound against door sound 2 + Title: 30 minutes later
            Ch1[22] = "Help! Can't anybody hear me?";
            //Title: 2 hours later
            Ch1[23] = "...";
            Ch1[24] = "There was no clock, nor any windows to tell the time. The atmosphere was dominated by an awful silence as I sat there on the bed, frustrated from my fruitless efforts to call out to someone."; //
            Ch1[25] = "What do I do?";
            Ch1[26] = "What if nobody comes? I'll be locked in here forever?"; 
            Ch1[27] = "What's up with this place anyway? It looks like a prison cell.";
            Ch1[28] = "Isn't there any way to escape?";
            Ch1[29] = "After sitting in the cold room for what must have been hours, I started to lose hope that I'd ever get out of there. But then..."; //
            // Small Doorhandle-rattle or Knock
            Ch1[30] = "!"; // TODO: font size = +30?
            Ch1[31] = "S-Someone finally came.";
            Ch1[32] = "Hey! I'm stuck in here, can you please call someone to open..."; //Sabrina
            Ch1[33] = "LET ME IN!";// Doorhandle-rattle // ???
            Ch1[34] = "Huh?";// Doorhandle-rattle // Sabrina
            Ch1[35] = "OPEN! OPEN THE DOOR GODDAMNIT!";// ??? //Doorhandle-rattle
            Ch1[36] = "As the man on the other side of the door screamed his lungs out, a feeling of uneasiness overcame me."; // Doorhandle-rattle // Sabrina
            Ch1[37] = "I wasn't sure where it came from or since when it started to appear, but a dense fog was now filling the room."; // Doorhandle-rattle
            // Intense Scream sound
            Ch1[38] = "After that sound, the door rattling stopped. And the fog dissipated unnaturally quickly"; //
            Ch1[39] = "I wanted to open my mouth and ask whether the man was still there, but my body wouldn't listen, because a certainty made its way into my mind. No matter what anyone would have said to me at that point, I would have still been convinced of this one fact."; //
            Ch1[40] = "That man is dead."; //
            Ch1[41] = "I could try to puzzle the pieces together how I wanted, the outcome would still be the same to me."; //
            Ch1[42] = "I'm not even sure why I'm so convinced. But that man is undoubtedly dead. I was certain."; //
            Ch1[43] = "I tried to think about what could've happened outside that door and where this place is. The fear of a thought was trying to overtake my mind."; //
            Ch1[44] = "You're next."; //
            Ch1[45] = "I was starting to believe that maybe I was overthinking. I tried to calm down."; //
            Ch1[46] = "But from there, things just started to get worse."; //

            Ch1[47] = "Good morning, chosen one."; // director speech
            Ch1[48] = "I am Ms. Shineko, consider me to be your guide on this trial that lies before you.";
            Ch1[49] = "Please bear in mind that there are no input devices on your side of the screen, and as such, I am unable to hear or see you and can therefore not answer any questions.";
            Ch1[50] = "You have been chosen to partake in project Arbel, to save the world. My congratulations.";
            Ch1[51] = "Save the world?";
            Ch1[52] = "Your decisions in this project will decide mankind's fate. Let us hope that I made the right choice in picking you for the job.";
            Ch1[53] = "I will explain how this is going to proceed. Please listen carefully, as I will not repeat myself.";
            Ch1[54] = "You are currently locked up in your assigned room. Do not panic. This is part of the project procedure, for your own safety.";
            Ch1[55] = "What is she saying?";
            Ch1[56] = "You will find in your room: A bed, a toillet, a sink and a weapon.";
            Ch1[57] = "It is highly recommended that you pick up the weapon in your room. But it is not a necessity for what you are about to face.";
            Ch1[58] = "Outside this room is a place refered to as Hall.";
            Ch1[59] = "The Hall is a place that drives normal humans insane once they near it. Do not trust your senses while in the Hall. Also beware, as armed demons roam freely inside the Hall.";
            Ch1[60] = "D-Demons?...haha. Wait, did she say they are armed?";
            Ch1[61] = "As long as you are within your assigned room, you are safe from harm. But this will not do.";
            Ch1[62] = "Once a day at 12pm, starting from now, I will unlock this door for 8 hours.";
            Ch1[63] = "There are many other doors inside the Hall, some of which lead to places of interest. These doors will henceforth be refered to as hellgates.";
            Ch1[64] = "Only one hellgate will unlock per day. Your goal, every day, should be to search for this unlocked hellgate inside The Hall.";
            Ch1[65] = "Once your room is unlocked, it will allow you to move freely inside The Hall to search for that hellgate. It is recommended to run away from monsters in the Hall on sight.";
            Ch1[66] = "Once you make it through a hellgate, you will be faced with a trial.";
            Ch1[67] = "Your main objective in this project is to overcome all trials in this place. Then, and only then, will the exit door unlock.";
            Ch1[68] = "Keep in mind that 8 hours after your door was unlocked, I will lock the door again until 12 pm the next day. There will be no way to open the door from either side for the next 16 hours from that moment on.";
            Ch1[69] = "It is now 12 pm sharp. I will unlock the doors in accordance with the procedures.";
            Ch1[70] = "Best of luck to you, chosen one.";
            Ch1[71] = "..."; //Sabrina
            Ch1[72] = "The heck?";
            Ch1[73] = "But that sound. Did the door unlock?\nIf so, I'm getting out of here."; //=>Inspection Mode
            Ch1[74] = "its a sink.";
            Ch1[75] = "its a toillet.";
            Ch1[76] = "its a bed.";
            Ch1[77] = "its a shaft.";
            Ch1[78] = "its a door.";
            Ch1[79] = "its a screen.";
            Ch1[80] = "its a lights.";
            Ch1[81] = "its a chair.";
            Ch1[82] = "There's nothing left in the sink.";
            Ch1[83] = "The screen won't turn on.";
            Ch1[84] = "There's nothing left in the shaft.";


            Ch1[50] = "...";
            Ch1[51] = "The heck?";
            Ch1[52] = "And they even forgot to put the weapon in the room. What kind of half-assed project is this ? World saving my ass.";
            Ch1[53] = "At least the door is open now. I'm getting out of here."; //=>Inspection Mode
            Ch1[54] = "its a sink.";
            Ch1[55] = "its a toillet.";
            Ch1[56] = "its a bed.";
            Ch1[57] = "its a shaft.";
            Ch1[58] = "its a door.";
            Ch1[59] = "its a screen.";
            Ch1[60] = "its a lights.";
            Ch1[61] = "its a chair.";
            Ch1[62] = "There's nothing left in the sink.";
            Ch1[63] = "The screen won't turn on.";
            Ch1[64] = "There's nothing left in the shaft.";

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

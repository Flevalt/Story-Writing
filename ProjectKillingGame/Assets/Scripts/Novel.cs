using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novel : MonoBehaviour {

    public string[] currentCh; //all text of the current chapter for loading by external classes
    public float currentChapter = 1; //current chapter saved as integer
    public int currentLine = -1;

    private void Awake () {
        currentCh = getChapter (currentChapter);
    }

    public string[] getChapter (float currentChapter) {
        if (currentChapter == 0) {
            currentCh = new string[8];
            // Start of Prologue/Ch0
            currentCh[0] = "Earth. \nIt is the only planet with the right conditions for life to form.";
            currentCh[1] = "Right now, there are billions of people living on this dwarf of a planet among dozens of other lifeforms. All of them living out their fleeting lives.";
            currentCh[2] = "It didn't always used to look like this.";
            currentCh[3] = "The land we step on now used to be lava flowing around the surface. With close to no oxygen, it was nothing but a hostile molten sphere.";
            currentCh[4] = "And even now, that place is still there. A molten core, deep down into the Earth.";
            currentCh[5] = "In a way, you could say the Earth we know is nothing but a facade. Beautiful and lively on the outside, but its fiery and dangerous inner self still dormant inside.";
            currentCh[6] = "It makes you wonder for how long a place like Earth can act as a home to living creatures. And sometimes I wonder...";
            currentCh[7] = "...how many people can a small planet like Earth take?";

            return currentCh;
        } else if (currentChapter == 1) {
            currentCh = new string[9];
            currentCh[0] = "Uhhn..."; //Start of currentCh
            currentCh[1] = "I woke up in a room I had never seen before. I felt cold. \nThe room temperature was low."; //
            currentCh[2] = "Nhhg...";
            currentCh[3] = "Ah...!!";
            currentCh[4] = "As my eyes jumped between the room, I started to think that this room looked strangely empty."; //
            currentCh[5] = "This place...where am I?";
            currentCh[6] = "A sudden rush of pain overcame me. I started to notice that my entire body ached."; //
            currentCh[7] = "Oww..! My body feels like I was hit by a truck.";
            currentCh[8] = "I don't like the look of this. And this room gives off an eerie vibe. I'd better check outside.";
            //=>Inspection Mode

            return currentCh;
        } else if (currentChapter == 1.1f) {
            currentCh = new string[29];

            currentCh[0] = "Nnnngh..."; //=>Story Mode //door sound
            currentCh[1] = "What the heck? It won't open.";
            //Pound against door sound 1
            currentCh[2] = "Help! The door is stuck!";
            currentCh[3] = "Hello? Someone?";
            //Pound against door sound 2 + Title: 30 minutes later
            currentCh[4] = "Help! Can't anybody hear me?";
            //Title: 2 hours later
            currentCh[5] = "...";
            currentCh[6] = "There was no clock, nor any windows to tell the time. The atmosphere was dominated by an awful silence as I sat there on the bed, frustrated from my fruitless efforts to reach someone."; //
            currentCh[7] = "What do I do?";
            currentCh[8] = "What if nobody comes? I'll be locked in here forever?";
            currentCh[9] = "What's up with this place anyway? It looks like a prison cell.";
            currentCh[10] = "Isn't there any way to escape?";
            currentCh[11] = "After sitting in the cold room for what must have been hours, I started to lose hope that I'd ever get out of there. But then..."; //
            // Small Doorhandle-rattle or Knock
            currentCh[12] = "!"; // TODO: font size = +30?
            currentCh[13] = "S-Someone finally came.";
            currentCh[14] = "Hey! I'm stuck in here, can you please call someone to open-"; //Sabrina
            currentCh[15] = "LET ME IN!"; // Doorhandle-rattle // ???
            currentCh[16] = "Huh?"; // Doorhandle-rattle // Sabrina
            currentCh[17] = "OPEN! OPEN THE DOOR GODDAMNIT!"; // ??? //Doorhandle-rattle
            currentCh[18] = "As the man on the other side of the door screamed his lungs out, a feeling of uneasiness overcame me."; // Doorhandle-rattle // Sabrina
            currentCh[19] = "I wasn't sure where it came from or since when it started to appear, but a dense fog was now filling the room."; // Doorhandle-rattle
            // Intense Scream sound
            currentCh[20] = "After that sound, the door rattling stopped. And the fog dissipated unnaturally quickly"; //
            currentCh[21] = "I wanted to open my mouth and ask whether the man was still there, but my body wouldn't listen, because a certainty made its way into my mind. No matter what anyone would have said to me at that point, I would have still been convinced of this one fact."; //
            currentCh[22] = "That man is dead."; //
            currentCh[23] = "I could try to puzzle the pieces together how I wanted, the outcome would still be the same to me."; //
            currentCh[24] = "I'm not even sure why I'm so convinced. But that man is undoubtedly dead. I was certain."; //
            currentCh[25] = "I tried to think about what could've happened outside that door and where this place is. The fear of a thought was trying to overtake my mind."; //
            currentCh[26] = "\"You are next.\""; //
            currentCh[27] = "I was starting to believe that maybe I was overthinking. I tried to calm down."; //
            currentCh[28] = "But from there, things just started to get worse."; //

            return currentCh;
        } else if (currentChapter == 1.2f) {
            currentCh = new string[27];
            currentCh[0] = "Good morning, chosen one."; // director speech
            currentCh[1] = "I am Ms. Shineko, consider me to be your guide on this trial that lies before you.";
            currentCh[2] = "Please bear in mind that there are no input devices on your side of the screen, and as such, I am unable to hear or see you and can therefore not answer any questions.";
            currentCh[3] = "You have been chosen to partake in project Arbel, to save the world. My congratulations.";
            currentCh[4] = "Save the world?";
            currentCh[5] = "Your decisions in this project will decide mankind's fate. Let us hope that I made the right choice in picking you for the job.";
            currentCh[6] = "I will explain how this is going to proceed. Please listen carefully, as I will not repeat myself.";
            currentCh[7] = "You are currently locked up in your assigned room. Do not panic. This is part of the project procedure, for your own safety.";
            currentCh[8] = "What is she saying?";
            currentCh[9] = "You will find in your room: A bed, a toillet, a sink and a weapon.";
            currentCh[10] = "It is highly recommended that you pick up the weapon in your room. But it is not a necessity for what you are about to face.";
            currentCh[11] = "Outside this room is a place refered to as Hall.";
            currentCh[12] = "The Hall is a place that drives normal humans insane once they near it. Do not trust your senses while in the Hall. Also beware, as armed demons roam freely inside the Hall.";
            currentCh[13] = "D-Demons?...haha. Wait, did she say they are armed?";
            currentCh[14] = "As long as you are within your assigned room, you are safe from harm. But this will not do.";
            currentCh[15] = "Once a day at 12pm, starting from now, I will unlock this door for 8 hours.";
            currentCh[16] = "There are many other doors inside the Hall, some of which lead to places of interest. These doors will henceforth be refered to as hellgates.";
            currentCh[17] = "Only one hellgate will unlock per day. Your goal, every day, should be to search for this unlocked hellgate inside The Hall.";
            currentCh[18] = "Once your room is unlocked, it will allow you to move freely inside The Hall to search for that hellgate. It is recommended to run away from monsters in the Hall on sight.";
            currentCh[19] = "Once you make it through a hellgate, you will be faced with a trial.";
            currentCh[20] = "Your main objective in this project is to overcome all trials in this place. Then, and only then, will the exit door unlock.";
            currentCh[21] = "Keep in mind that 8 hours after your door was unlocked, I will lock the door again until 12 pm the next day. There will be no way to open the door from either side for the next 16 hours from that moment on.";
            currentCh[22] = "It is now 12 pm sharp. I will unlock the doors in accordance with the procedures.";
            currentCh[23] = "Best of luck to you, chosen one.";
            currentCh[24] = "..."; //Sabrina
            currentCh[25] = "The heck?";
            currentCh[26] = "But that sound. Did the door unlock?\nIf so, I'm getting out of here."; //=>Inspection Mode

            return currentCh;
        } else if (currentChapter == 1.11f) {
            currentCh = new string[11];
            currentCh[0] = "A regular sink. Hey, there is something inside.";
            currentCh[1] = "An old toilet model. At least it seems clean.";
            currentCh[2] = "The bed I was sleeping in. Why can't I remember how I got here?";
            currentCh[3] = "A ventilation shaft. Hm? The grid is loose. There is something inside the shaft.";
            currentCh[4] = "It's a door.";
            currentCh[5] = "It's a screen. Let's try to turn it on.";
            currentCh[6] = "The lights are on...weird, I don't see a light switch anywhere.";
            currentCh[7] = "A chair with a simplistic design. It looks uncomfortable.";
            currentCh[8] = "There's nothing left in the sink.";
            currentCh[9] = "The screen won't turn on.";
            currentCh[10] = "There's nothing left in the shaft.";

            return currentCh;
        } else {
            currentCh = new string[7];
            currentCh[0] = "line1 of chapter 3";
            currentCh[1] = "and line2";
            currentCh[2] = "or line3";
            currentCh[3] = "why line4";
            currentCh[4] = "hmm line5";
            currentCh[5] = "well line6";
            currentCh[6] = "sure, line7";

            return currentCh;
        }
    }

    /**
     * Adjusts line- and chapter numbers accordingly.
     */
    public void progressNovel () {
        updateCurrentChapter ();
        resetCurrentLine ();
    }

    /**
     * Checks if currentLine needs to be reset and resets it.
     * Needs to be called in every WriteAttempt in TextWrite class.
     */
    public void resetCurrentLine () {
        if (Equals (currentLine, currentCh.Length - 1)) {
            currentLine = -1;
        }
    }
    /**
     * Checks if current chapter ended with the last line and switches
     * to the next chapter.
     * Needs to be called in every WriteAttempt in TextWrite class.
     */
    private void updateCurrentChapter () {
        if (Equals (currentLine, currentCh.Length - 1)) {
            if (currentChapter == 0) {
                currentChapter++;
            } else {
                currentChapter += 0.1f;
            }
        }
    }

}
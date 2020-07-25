using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour {
    public HeroDB HeroDB;
    List<Hero> Bs;
    List<Hero> As;
    List<Hero> Ss;
    List<Hero> Celestials;
    public Player Player;
    public List<Hero> lastPulls;

    void Start () {
        lastPulls = new List<Hero> ();
        Bs = new List<Hero> ();
        As = new List<Hero> ();
        Ss = new List<Hero> ();
        HeroDB = new HeroDB ();
        Celestials = new List<Hero> ();
        //Fills the more specific lists besides heroDB.
        foreach (Hero hero in HeroDB.heroDB) {
            if (Equals (hero.rarity, "B")) {
                Bs.Add (hero);
            } else if (Equals (hero.rarity, "A")) {
                As.Add (hero);
            } else if (Equals (hero.faction, "Celestials") || Equals (hero.faction, "Fallen")) {
                Celestials.Add (hero);
            } else if (Equals (hero.rarity, "S")) {
                Ss.Add (hero);
            }
        }
    }

    public void regularPull () {
        Hero hero = Pull (0.3f, 0.05f, 0.004f, Player.pityStreak); // 0.8f, 0.146f
        Player.heroes.Add (hero);
    }

    /*
     * Generic logic for pulling 10 units.
     */
    public void pullTen () {
        for (int i = 0; i < 10; i++) {
            Hero hero = Pull (0.446f, 0.05f, 0.004f, Player.pityStreak);
            Player.heroes.Add (hero);
        }
    }

    /*
     * Generic logic for pulling units.
     */
    public Hero Pull (float rateA, float rateS, float rateCelestial, int pityStreak) {
        Hero hero = new Hero ();
        System.Random Random = new System.Random();
        double rarityTrigger = Random.NextDouble();
        int heroTrigger;
        double wishTrigger = Random.NextDouble();
        // Pulled S unit
        if ((pityStreak == 29) || (rarityTrigger <= rateS)) {
            // Pull either Celestials or regular S
            if (rarityTrigger <= rateCelestial) {
                heroTrigger = Random.Next (0, NonNegative (Celestials.Count - 1));
                hero = Celestials[heroTrigger];
            } else {
                // Pull from wishlist with 85% chance
                if (wishTrigger <= 0.85f) {
                    hero = Player.wishlist[Random.Next (0, NonNegative (Player.wishlist.Count - 1))];
                } else {
                    heroTrigger = Random.Next (0, NonNegative (Ss.Count - 1));
                    hero = Ss[heroTrigger];
                }
            }
            Player.pityStreak = 0;
        } else if (rarityTrigger <= rateA) {
            heroTrigger = Random.Next (0, NonNegative (As.Count - 1));
            hero = As[heroTrigger];
            Player.pityStreak++;
        } else {
            heroTrigger = Random.Next (0, NonNegative (Bs.Count - 1));
            hero = Bs[heroTrigger];
            Player.pityStreak++;
        }

        lastPulls.Add (hero);
        return hero;
    }

    // Caps a negative number to 0.
    private int NonNegative (int number) {
        if (number < 0) {
            return 0;
        } else {
            return number;
        }
    }

    public void flushLastPulls() {
        lastPulls = new List<Hero>();
    }

}
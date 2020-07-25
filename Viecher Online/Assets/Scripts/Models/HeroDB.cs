using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDB {
    public List<Hero> heroDB;
    public Dictionary<string, Hero> heroDictionary;

    public HeroDB () {
        heroDB = new List<Hero> ();
        heroDictionary = new Dictionary<string, Hero>();
        // 3*
        Hero Rob = new Hero ("Rob", "B", "Mortals", "Strength", "Warrior", "DPS", "None", Resources.Load<Sprite>("GFX/Sprites/mortals1"));
        heroDB.Add (Rob);
        Hero Leon = new Hero ("Leon", "B", "Valders", "Strength", "Warrior", "DPS", "None", Resources.Load<Sprite>("GFX/Sprites/valders1"));
        heroDB.Add (Leon);
        Hero Lard = new Hero ("Lard", "B", "Ancients", "Strength", "Warrior", "DPS", "None", Resources.Load<Sprite>("GFX/Sprites/ancients1"));
        heroDB.Add (Lard);
        Hero Gobli = new Hero ("Gobli", "B", "Tribals", "Strength", "Warrior", "DPS", "None", Resources.Load<Sprite>("GFX/Sprites/tribals1"));
        heroDB.Add (Gobli);
        // 4*
        Hero Rupert = new Hero ("Rupert", "A", "Mortals", "Strength", "Warrior", "Burst", "None", Resources.Load<Sprite>("GFX/Sprites/mortals2"));
        heroDB.Add (Rupert);
        Hero Warg = new Hero ("Warg", "A", "Valders", "Strength", "Warrior", "Burst", "None", Resources.Load<Sprite>("GFX/Sprites/valders2"));
        heroDB.Add (Warg);
        Hero Laslow = new Hero ("Laslow", "A", "Ancients", "Strength", "Warrior", "Burst", "None", Resources.Load<Sprite>("GFX/Sprites/ancients2"));
        heroDB.Add (Laslow);
        Hero Ikk = new Hero ("Ikk", "A", "Tribals", "Strength", "Warrior", "Burst", "None", Resources.Load<Sprite>("GFX/Sprites/tribals2"));
        heroDB.Add (Ikk);
        // 5*
        Hero Howard = new Hero ("Howard", "S", "Ancients", "Intelligence", "Mage", "Burst", "Fire Sword", Resources.Load<Sprite>("GFX/Sprites/a7"));
        heroDB.Add (Howard);
        heroDictionary.Add("Howard", Howard);
        Hero Gertrud = new Hero ("Gertrud", "S", "Tribals", "Agility", "Assassin", "Burst", "Clock Lance", Resources.Load<Sprite>("GFX/Sprites/a6"));
        heroDB.Add (Gertrud);
        heroDictionary.Add("Gertrud", Gertrud);
        // 5* Celestials
        Hero Gabriel = new Hero ("Gabriel", "S", "Celestials", "Agility", "Ranged", "DPS", "Infinity Gloves", Resources.Load<Sprite>("GFX/Sprites/a5"));
        heroDB.Add (Gabriel);
        heroDictionary.Add("Gabriel", Gabriel);
        // 5* Fallen
        Hero Maggard = new Hero ("Maggard", "S", "Fallen", "Intelligence", "Mage", "Control", "Maggard's Orwell", Resources.Load<Sprite>("GFX/Sprites/a4"));
        heroDB.Add (Maggard);
        heroDictionary.Add("Maggard", Maggard);
        // 5* Dreams
        Hero Helck = new Hero ("Helck", "S", "Dreams", "Strength", "Tank", "Sustain", "Destiny's Hand", Resources.Load<Sprite>("GFX/Sprites/a3"));
        heroDB.Add (Helck);
        heroDictionary.Add("Helck", Helck);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    public string name;
    public string rarity;
    public string faction; 
    public string statFocus;
    public string profession; 
    public string role; 
    public string SI;

    public int level;
    public int sigLevel;
    public int ascensionLevel;

    public int range;
    public int atk;
    public int def;
    public int hp;
    public int acc;
    public int dodge;
    public int crit;
    public int critDmg;
    public int energyRegen;

    public Sprite avatar;

    public Hero(){}

    public Hero(string name, string rarity, string faction, string statFocus, string profession, string role, string SI, Sprite avatar) {
        this.name = name;
        this.rarity = rarity;
        this.faction = faction;
        this.statFocus = statFocus;
        this.profession = profession;
        this.role = role;
        this.SI = SI;
        this.avatar = avatar;
    }

    public void SetStats(int range, int atk, int def, int hp, int acc, int dodge, int crit, int critDmg, int energyRegen){
        this.range = range;
        this.atk = atk;
        this.def = def;
        this.hp = hp;
        this.acc = acc;
        this.dodge = dodge;
        this.crit = crit;
        this.critDmg = critDmg;
        this.energyRegen = energyRegen;
    }

    public void SetProgress(int level, int sigLevel, int ascensionLevel) {
        this.level = level;
        this.sigLevel = sigLevel;
        this.ascensionLevel = ascensionLevel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gold, orbs, souls;
    public float goldP1, orbsP1, soulsP1;
    public float collectionDeltaTime; // The last time resources have been collected
    public int stage, stageLevel;
    public List<Hero> heroes;
    public int pityStreak;
    public List<Hero> wishlist;
    public Tavern Tavern;

    void Start () {
        stage = 1;
        stageLevel = 1;
        heroes = new List<Hero>();
        wishlist = new List<Hero>();
        wishlist.Add(Tavern.HeroDB.heroDictionary["Gabriel"]);
        wishlist.Add(Tavern.HeroDB.heroDictionary["Maggard"]);
        wishlist.Add(Tavern.HeroDB.heroDictionary["Helck"]);
    }

    public void SetCollectionDeltaTime(float time) {
        collectionDeltaTime = time;
    }
}

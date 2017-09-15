using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private string[] itemArray; //item Names
    private Sprite[] itemSprites; //item Sprites
    public Sprite s1;
    public Sprite s2;

    void Awake()
    {
        itemArray = new string[200];
        itemSprites = new Sprite[200];
        itemArray[0] = "Coins";
        itemArray[1] = "Globberus Maximus";
        itemArray[2] = "Colt .357";

        itemSprites[0] = s1;
        itemSprites[1] = s2;
        itemSprites[2] = s1;
    }

    public string getItemName(int i)
    {
        string s = itemArray[i];
        return s;
    }

    public Sprite getItemSprite(int i)
    {
        Sprite s = itemSprites[i];
        return s;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

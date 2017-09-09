using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCon : MonoBehaviour {

    //(to be extended by more sprites)
    public Sprite c1;
    public Sprite c2;

    //Returns an avatar-sprite for Char1&2 depending on index-input
    public Sprite loadAvatar(int i)
    {
        switch (i)
        {
            case 1:
                return c1;
            case 2:
                return c2;
        }
        return c1;
    }
}

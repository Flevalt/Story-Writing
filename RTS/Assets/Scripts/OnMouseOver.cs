using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour {

    public Color OnMouseOverColor;
    public Color OnMouseLeaveColor;

    void OnMouseEnter()
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.r += 0.3f;
        color.b += 0.3f;
        color.g += 0.3f;

        GetComponent<SpriteRenderer>().material.color = color;
    }

    void OnMouseExit()
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.r -= 0.3f;
        color.b -= 0.3f;
        color.g -= 0.3f;
        GetComponent<SpriteRenderer>().material.color = color;
    }
}

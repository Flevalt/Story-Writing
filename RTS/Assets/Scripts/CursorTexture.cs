using UnityEngine;
using System.Collections;

public class CursorTexture : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode;
    public Vector2 cursorLoc;

    private void Start()
    {
        cursorMode = CursorMode.Auto;
        cursorLoc = Vector2.zero;
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, cursorLoc, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
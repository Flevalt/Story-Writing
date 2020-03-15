using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseAnimator : MonoBehaviour {
    public Sprite sprite1;
    public Sprite sprite2;
    public int currentMouse = 1;

    private void Awake () {
        Cursor.visible = false;
    }

    public void changeMouse (int i) {
        switch (i) {
            case 1:
                gameObject.GetComponent<Image> ().sprite = sprite1;
                currentMouse = 1;
                break;
            case 2:
                gameObject.GetComponent<Image> ().sprite = sprite2;
                currentMouse = 2;
                break;
        }
    }

    private void Update () {
        // Follow Cursor
        GameObject.Find ("Mouse1").GetComponent<RectTransform> ().position = Input.mousePosition;
        //Rotate
        RotateMouse ();
    }

    private void RotateMouse () {
        if (GameObject.Find ("Mouse1").GetComponent<MouseAnimator> ().currentMouse == 2) {
            GameObject.Find ("Mouse1").GetComponent<RectTransform> ().Rotate (new Vector3 (0f, 0f, -45f) * Time.deltaTime/4);
            //GameObject.Find ("Mouse1").GetComponent<RectTransform> ().position = Input.mousePosition + new Vector3 (0f, -1f, 0f);
        }
    }

}
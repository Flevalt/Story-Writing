using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseAnim : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public int currentMouse = 1;

    public void changeMouse(int i)
    {
        switch (i)
        {
            case 1:
                GameObject.Find("Mouse1").GetComponent<Image>().sprite = sprite1;
                currentMouse = 1;
                break;
            case 2:
                GameObject.Find("Mouse1").GetComponent<Image>().sprite = sprite2;
                currentMouse = 2;
                break;
        }
    }

    private void Update()
    {
        GameObject.Find("Mouse1").GetComponent<RectTransform>().position = Input.mousePosition;
    }

}

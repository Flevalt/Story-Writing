using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
* Changes the Mouse Cursor Icon if Mouse Hovers over this Object.
*/

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
        public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("Mouse1").GetComponent<MouseAnimator>().changeMouse(2);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Mouse1").GetComponent<MouseAnimator>().changeMouse(1);
    }
}

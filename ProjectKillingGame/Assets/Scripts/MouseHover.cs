using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("Mouse1").GetComponent<MouseAnim>().changeMouse(2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Mouse1").GetComponent<MouseAnim>().changeMouse(1);
    }
}

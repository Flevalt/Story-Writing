using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnim : MonoBehaviour
{

    private void Update()
    {
        GameObject.Find("Mouse").GetComponent<RectTransform>().position = Input.mousePosition;
        GameObject.Find("Mouse").GetComponent<RectTransform>().Rotate(new Vector3(0f, 0f, 45f)*Time.deltaTime);
    }

}

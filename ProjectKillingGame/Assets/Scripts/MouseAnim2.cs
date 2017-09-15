using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnim2 : MonoBehaviour {

    public int i;
    public float j;

    private void Update()
    {
        GameObject.Find("Mouse"+i).GetComponent<RectTransform>().position = transform.position = Vector3.Lerp(GameObject.Find("Mouse2").transform.position, Input.mousePosition, Time.deltaTime*j);
        GameObject.Find("Mouse"+i).GetComponent<RectTransform>().Rotate(new Vector3(0f, 0f, -45f) * Time.deltaTime);
    }

}

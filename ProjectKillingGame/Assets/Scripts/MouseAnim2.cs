using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnim2 : MonoBehaviour {

    public int i;
    public float j;

    private void Update()
    {
        //Follow mouse slowly
        // GameObject.Find("Mouse"+i).GetComponent<RectTransform>().position = transform.position = Vector3.Lerp(GameObject.Find("Mouse2").transform.position, Input.mousePosition, Time.deltaTime*j);
        if(GameObject.Find("Mouse1").GetComponent<MouseAnim>().currentMouse == 2)
        {
            GameObject.Find("Mouse" + i).GetComponent<RectTransform>().Rotate(new Vector3(0f, 0f, -45f) * Time.deltaTime);
            GameObject.Find("Mouse" + i).GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(0f, -1f, 0f);
        }
        else
        {
            GameObject.Find("Mouse" + i).GetComponent<RectTransform>().position = new Vector3(1000f, 0f, 0f);
        }


    }



}

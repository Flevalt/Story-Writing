using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

    RectTransform.Axis Haxis;
    RectTransform.Axis Vaxis;

    private void Start()
    {
        Haxis = RectTransform.Axis.Horizontal;
        Vaxis = RectTransform.Axis.Vertical;
        StartCoroutine(animate());
    }

    IEnumerator animate()
    {
        for (int i = 0; i < 1; i--)
        {
            GameObject.Find("NextPage").GetComponent<RectTransform>().localScale = new Vector3(1.2f,1.2f,1f);
            yield return new WaitForSeconds(0.8f);
            GameObject.Find("NextPage").GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            yield return new WaitForSeconds(0.8f);
        }
    }
}

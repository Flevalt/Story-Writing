using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColor : MonoBehaviour {

    Color r = new Color(0.05f, 0f, 0f, 1);
    Color b = new Color(0f, 0.05f, 0f, 1);
    Color g = new Color(0f, 0f, 0.05f, 1);

    // Use this for initialization
    void Start () {
        GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(Color.clear);
        StartCoroutine(changeCol());
	}

    IEnumerator changeCol()
    {
        for (int c = 0; c < 20; c++)
        {
            GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() + r);
            GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() + b);
            yield return new WaitForSeconds(0.08f);
        }
        for (int i=0;i<1;i--) {
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() - r);
                yield return new WaitForSeconds(0.08f);
            }
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() + r);
                yield return new WaitForSeconds(0.08f);
            }
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() - b);
                yield return new WaitForSeconds(0.08f);
            }
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() + b);
                yield return new WaitForSeconds(0.08f);
            }
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() + g);
                yield return new WaitForSeconds(0.08f);
            }
            for (int c = 0; c < 20; c++)
            {
                GameObject.Find("UIBG").GetComponent<CanvasRenderer>().SetColor(GameObject.Find("UIBG").GetComponent<CanvasRenderer>().GetColor() - g);
                yield return new WaitForSeconds(0.08f);
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

    public float j, k, l;
    private bool finish;
    private int count;

	void Start () {
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        if (finish == false)
        {
                GameObject.Find("Mouse" + j).GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Mouse" + j).GetComponent<CanvasRenderer>().GetAlpha() - k);
                yield return new WaitForSeconds(l);
                count += 1;

                if (count < 5)
                {
                StartCoroutine(blink());
                }

                else
                {
                count = 0;
                StartCoroutine(blink2());
            }
        }

    }
    IEnumerator blink2()
    {
        if (finish == false)
        {
            GameObject.Find("Mouse" + j).GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Mouse" + j).GetComponent<CanvasRenderer>().GetAlpha() + k);
            yield return new WaitForSeconds(l);
            count += 1;

            if (count < 5)
            {
                StartCoroutine(blink2());
            }

            else
            {
                count = 0;
                StartCoroutine(blink());
            }
        }

    }
}

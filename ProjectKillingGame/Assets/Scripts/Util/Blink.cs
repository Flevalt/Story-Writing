using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

    public float k, l;
    private bool finish;
    private int count;

	void Start () {
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        if (finish == false)
        {
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(gameObject.GetComponent<CanvasRenderer>().GetAlpha() - k);
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
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(gameObject.GetComponent<CanvasRenderer>().GetAlpha() + k);
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

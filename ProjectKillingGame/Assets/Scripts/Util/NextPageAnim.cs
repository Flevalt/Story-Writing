using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageAnim : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(animate());
    }

    IEnumerator animate()
    {
        for (int i = 0; i < 1; i--)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.2f,1.2f,1f);
            yield return new WaitForSeconds(0.6f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            yield return new WaitForSeconds(0.6f);
        }
    }
}

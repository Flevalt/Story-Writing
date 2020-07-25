using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {
    float camSpeed;
    int maxBoundary;
    int minBoundary;
    public GUIManager GUIManager;

    void Start () {
        camSpeed = 0.05f;
    }

    void Update () {
        if (GUIManager.heroWindowOpen) {
            ListenHorizontally();
        }
    }

    private void ListenHorizontally () {
        // Move Camera
        if (Input.GetAxis ("Horizontal") != 0) {
            transform.position += new Vector3 (Input.GetAxis ("Horizontal") * camSpeed, 0, 0);
            //Limit Movement horizontally
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp (transform.position.x, 0, 50);
            transform.position = clampedPosition;
        }
    }
}
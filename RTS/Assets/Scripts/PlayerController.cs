using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float mvspd;

    private void Start()
    {
        mvspd = 5f;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * mvspd;
        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody2D>().velocity = Vector3.left * mvspd;
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody2D>().velocity = Vector3.up * mvspd;
        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody2D>().velocity = Vector3.down * mvspd;

        if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.W)))
            GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * mvspd;
        if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
            GetComponent<Rigidbody2D>().velocity = new Vector3(1, -1, 0) * mvspd;
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
            GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * mvspd;
        if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.S)))
            GetComponent<Rigidbody2D>().velocity = new Vector3(-1, -1, 0) * mvspd;

        if (Input.GetKeyUp(KeyCode.D))
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (Input.GetKeyUp(KeyCode.W))
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (Input.GetKeyUp(KeyCode.S))
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (Input.GetKeyUp(KeyCode.A))
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}

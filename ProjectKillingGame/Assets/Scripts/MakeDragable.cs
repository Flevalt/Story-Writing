using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MakeDragable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform target;
    private bool isMouseDown = false;
    private Vector3 startMousePosition;
    private Vector3 startPosition;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;

        startPosition = target.position;
        startMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData dt)
    {

        isMouseDown = false;

        if (shouldReturn)
        {
            target.position = new Vector3(324f, 240f, 0f);
        }
        shouldReturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > 820 || target.position.x < -200 || target.position.y > 600 || target.position.y < -100)
        {
            shouldReturn = true;
        }

        if (isMouseDown)
        {
            Vector3 currentPosition = Input.mousePosition;

            Vector3 diff = currentPosition - startMousePosition;

            Vector3 pos = startPosition + diff;

            target.position = pos;
        }
    }
}

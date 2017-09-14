using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inspection : MonoBehaviour {

    public Sprite img;

    public void instObject(int objectId, float xPos, float yPos, float width, float height)
    {
        GameObject iOO = new GameObject(objectId.ToString());
        GameObject iO = Instantiate(iOO);
        iO.name = "iO(Inst)" + objectId;
        Destroy(iOO);

        Image im = iO.AddComponent<Image>();
        im.sprite = img;

        iO.transform.SetParent(GameObject.Find("Canvas").transform, false);

        iO.GetComponent<RectTransform>().localPosition = new Vector2(xPos, yPos);
        iO.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        iO.AddComponent<Button>().onClick.AddListener(() => {
            displayText(objectId);
        });
    }

    public void displayText(int id)
    {
        GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f);
        GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(1f);
        GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(1f);
    }

    public void onHover()
    {

    }

    //TODO: Animate mouse on hover
    //TODO: popup textbox and write text
    //TODO: little animation + item get
}

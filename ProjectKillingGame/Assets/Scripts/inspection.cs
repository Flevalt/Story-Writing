using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inspection : MonoBehaviour {

    public Sprite img;
    private Controller controller;
    private Novel novel;
    private TextBox textbox;
    private TextWrite tw;
    private Navigation noneNav = new Navigation();

    private void Start()
    {
        textbox = GameObject.Find("Textbox").GetComponent<TextBox>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        novel = GameObject.Find("NovelStorage").GetComponent<Novel>();
    }

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

        noneNav.mode = Navigation.Mode.None;
        Button btn = iO.AddComponent<Button>();
        btn.navigation = noneNav;
        btn.onClick.AddListener(() => {
            displayText(objectId);
        });

        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnim>();
        
    }

    public void displayText(int id)
    {
        for (int i=1;i<9;i++)
        {
            GameObject.Find("iO(Inst)" + i).GetComponent<Button>().enabled = false; 
        }

        GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f);
        GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(1f);
        GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(1f);
        controller.charDisplay(1);
        switch (id)
        {
            case 1:
                novel.setCurrentLine(54);
                break;
            case 2:
                novel.setCurrentLine(55);
                break;
            case 3:
                novel.setCurrentLine(56);
                break;
            case 4:
                novel.setCurrentLine(57);
                break;
            case 5:
                novel.setCurrentLine(58);
                break;
            case 6:
                novel.setCurrentLine(59);
                break;
            case 7:
                novel.setCurrentLine(60);
                break;
            case 8:
                novel.setCurrentLine(61);
                break;
        }
        controller.gameMode = 0;
        textbox.createTextWriterInst();
        tw = GameObject.Find("textwriter(Inst)" + textbox.txtWriterNr).GetComponent<TextWrite>();
        tw.attemptInspectionWriting();
    }

    public void onHover()
    {

    }

    //TODO: Animate mouse on hover
    //TODO: popup textbox and write text
    //TODO: little animation + item get
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inspection : MonoBehaviour {

    public Sprite img;
    private Controller controller;
    public Items items;
    private Novel novel;
    private TextBox textbox;
    private TextWrite tw;
    private Navigation noneNav = new Navigation();
    public int inspectionType; //0 = text, 1 = itemFound, 2 = coinsFound, 3 = decision.
    public int lastClicked; //last inspection object clicked
    public int itemId; //item id for itemfound
    private int coinAmount; //obtained coin amount
    private int decision; //decision id for decision

    public int itemFound1; //the nr represents the itemID, the value if true=1 or false=0
    public int itemFound2;
    public int itemFound3;
    public int itemFound4;
    public int itemFound5;
    public int itemFound6;
    public int itemFound7;
    public int itemFound8;
    public int itemFound9;
    public int itemFound10;
    public int itemFound11;
    public int itemFound12;
    public int itemFound13;
    public int itemFound14;
    public int itemFound15;
    public int itemFound16;
    public int itemFound17;
    public int itemFound18;
    public int itemFound19;
    public int itemFound20;
    public int itemFound21;
    public int itemFound22;
    public int itemFound23;
    public int itemFound24;
    public int itemFound25;
    public int itemFound26;
    public int itemFound27;
    public int itemFound28;
    public int itemFound29;
    public int itemFound30;
    public int itemFound31;
    public int itemFound32;

    private void Start()
    {
        //hide ItemObtained Menu 
        GameObject.Find("YouFound").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("YouFoundText").GetComponent<CanvasRenderer>().SetAlpha(0f);
        GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().SetAlpha(0f);

        textbox = GameObject.Find("Textbox").GetComponent<TextBox>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        novel = GameObject.Find("NovelStorage").GetComponent<Novel>();
    }

    //instantiate itemFound 
    // @objectID = inspection object; 
    // @itemObjectID = inspection object that drops items;
    // @itemID = the item that drops;
    public void instObject(int objectId, float xPos, float yPos, float width, float height, int itemObjectID, int itemID)
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
        addbuttonListener(btn, itemObjectID, objectId, itemID);

        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnim>();
        iO.AddComponent<MouseHover>();
    }

    //add different listener during load
    private void addbuttonListener(Button btn, int itemFoundId, int objectId, int itemID)
    {
        btn.navigation = noneNav;
        switch (itemFoundId)
        {
            case 1:
                            btn.onClick.AddListener(() => {
                            lastClicked = objectId;
                            itemId = itemID;
                            inspectionType = 1; //item found
                            displayText(objectId);
                            itemFound1 = 1; //if true, listener has to be changed on click
        });
                break;
            case 2:
                    btn.onClick.AddListener(() => {
                    lastClicked = objectId;
                    itemId = itemID;
                    coinAmount = 1;
                    inspectionType = 2; //coin found
                    displayText(objectId);
                    itemFound2 = 1;
                });
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    //instantiate pure Text
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
            lastClicked = objectId;
            inspectionType = 0;
            displayText(objectId);
        });

        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnim>();
        iO.AddComponent<MouseHover>();
    }

    //change listener if the inspection element had more than just text
    public void changeListener(int objectId)
    {
        GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.RemoveAllListeners();
        switch (objectId)
        {
            case 1:
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                    lastClicked = objectId; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText(9);
                });
                break;
            case 6:
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                lastClicked = objectId; //for changing listener of lastClicked during Textbox
                inspectionType = 0;
                displayText(10);
                });
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 7:
                break;
        }
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
            case 9:
                novel.setCurrentLine(62);
                break;
            case 10:
                novel.setCurrentLine(63);
                break;
        }
        controller.gameMode = 0;
        textbox.createTextWriterInst();
        tw = GameObject.Find("textwriter(Inst)" + textbox.txtWriterNr).GetComponent<TextWrite>();
        tw.attemptInspectionWriting();
    }

    public int getCoinAmount()
    {
        return coinAmount;
    }

}

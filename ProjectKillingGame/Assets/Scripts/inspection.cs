using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Manages the Logic for inspecting Items on the screen during Inspection Mode.
*/

public class inspection : MonoBehaviour {

    public Sprite img;
    public Items items;
    public Novel novel;
    public Controller controller;
    public TextBox textbox;
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

    public UIManager UIManager;

    private void Start()
    {
        //Hide Decision & ItemObtained Windows
        UIManager.closeDecisionWindow();
        UIManager.closeItemObtainedWindow();

        GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);
    }




    //Create inspection element that switches to Story Mode
    public void instStoryObject(int objectId, float xPos, float yPos, float width, float height)
    {
        GameObject iOO = new GameObject(objectId.ToString());
        GameObject iO = Instantiate(iOO);
        iO.name = "iO(Inst)" + objectId;
        Destroy(iOO);

        Image im = iO.AddComponent<Image>();
        im.sprite = img;

        iO.transform.SetParent(GameObject.Find("InspectionElements").transform, false);

        iO.GetComponent<RectTransform>().localPosition = new Vector2(xPos, yPos);
        iO.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        noneNav.mode = Navigation.Mode.None;
        Button btn = iO.AddComponent<Button>();
        btn.navigation = noneNav;
        switch (objectId) //add different listener for each storyobject
        {
            case 5:
                btn.onClick.AddListener(() => {
                    lastClicked = objectId;

                    GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

                    controller.gameMode = 0;
                    UIManager.charDisplay(1);
                    controller.enableWrite = true;
                    novel.setCurrentLine(18);
                    GameObject.Find("Textbox").GetComponent<Text>().text = novel.getCurrentCh(novel.savedIndex)[novel.getCurrentLine()];
                    controller.startCh1_1();
                    GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    textbox.playSFX();
                });
                break;
        }


        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnimator>();
        iO.AddComponent<MouseHover>();
    }

    //Create inspection element for Decision
    public void instObject(int objectId, float xPos, float yPos, float width, float height, int itemObjectID, int itemID, int decisionId)
    {
        GameObject iOO = new GameObject(objectId.ToString());
        
        GameObject iO = Instantiate(iOO);
        iO.name = "iO(Inst)" + objectId;
        Destroy(iOO);

        Image im = iO.AddComponent<Image>();
        im.sprite = img;
        
        iO.transform.SetParent(GameObject.Find("InspectionElements").transform, false);

        iO.GetComponent<RectTransform>().localPosition = new Vector2(xPos, yPos);
        iO.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        noneNav.mode = Navigation.Mode.None;
        Button btn = iO.AddComponent<Button>();
        addbuttonDecisionListener(btn, itemObjectID, objectId, itemID, decisionId);

        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnimator>();
        iO.AddComponent<MouseHover>();
    }

    //Create inspection element that finds item
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

        iO.transform.SetParent(GameObject.Find("InspectionElements").transform, false);

        iO.GetComponent<RectTransform>().localPosition = new Vector2(xPos, yPos);
        iO.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        noneNav.mode = Navigation.Mode.None;
        Button btn = iO.AddComponent<Button>();
        addbuttonListener(btn, itemObjectID, objectId, itemID);

        iO.AddComponent<PolygonCollider2D>();
        iO.AddComponent<MouseAnimator>();
        iO.AddComponent<MouseHover>();
    }

    //add different listener for decisions
    private void addbuttonDecisionListener(Button btn, int itemFoundId, int objectId, int itemID, int decisionID)
    {
        btn.navigation = noneNav;
        switch (itemFoundId)
        {
            case 1:
                break;
            case 2:
            case 3:
                btn.onClick.AddListener(() => {
                    lastClicked = objectId;
                    itemId = itemID;
                    inspectionType = 3; //decision
                    decision = 1; //for switch case in TextBox
                    displayText(objectId);
                });
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    //add different listener for itemFounds
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

        iO.transform.SetParent(GameObject.Find("InspectionElements").transform, false);

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
        iO.AddComponent<MouseAnimator>();
        iO.AddComponent<MouseHover>();
    }

    //change listener if the inspection element had more than just text
    public void changeListener(int objectId, int param)
    {
        GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.RemoveAllListeners();
        switch (param)
        {
            case 1: // change sink text
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                    lastClicked = objectId; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText(9);
                });
                break;
            case 2: // change door(id=5) to move into Round1, Phase1 Hall.
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                    GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(2000f, 0f);
                    lastClicked = objectId; //for changing listener of lastClicked during Textbox
                inspectionType = 3;
                GameObject.Find("SFX7").GetComponent<AudioSource>().Play();
                    GameObject.Find("MainCam").GetComponent<Transform>().localPosition = new Vector3(0f, -10f, -10f);
                    controller.gameMode = 2;
                });
                break;
            case 6: //change screen text
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                lastClicked = objectId; //for changing listener of lastClicked during Textbox
                inspectionType = 0;
                displayText(10);
                });
                break;
            case 3:
                break;
            case 4: //change shaft text
                GameObject.Find("iO(Inst)" + objectId).GetComponent<Button>().onClick.AddListener(() => {
                    lastClicked = objectId; //for changing listener of lastClicked during Textbox
                    inspectionType = 0;
                    displayText(11);
                });
                break;
            case 5:
                break;
            case 7:
                break;
        }
    }

    public void displayText(int id)
    {
        GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);
        GameObject.Find("Mouse1").GetComponent<MouseAnimator>().changeMouse(1);

        GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(1f);
        UIManager.showNameBox();
        UIManager.charDisplay(1);
        switch (id)
        {
            case 1:
                novel.setCurrentLine(74);
                break;
            case 2:
                novel.setCurrentLine(75);
                break;
            case 3:
                novel.setCurrentLine(76);
                break;
            case 4:
                novel.setCurrentLine(77);
                break;
            case 5:
                novel.setCurrentLine(78);
                break;
            case 6:
                novel.setCurrentLine(79);
                break;
            case 7:
                novel.setCurrentLine(80);
                break;
            case 8:
                novel.setCurrentLine(81);
                break;
            case 9:
                novel.setCurrentLine(82);
                break;
            case 10:
                novel.setCurrentLine(83);
                break;
            case 11:
                novel.setCurrentLine(84);
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

    public int getDecision()
    {
        return decision;
    }

}

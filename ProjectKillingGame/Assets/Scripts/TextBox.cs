using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public Novel novel;
    public Items items;
    public SpriteCon spritecontainer;
    private GameObject textwriter;
    private Controller controller;
    private TitleWrite titlewrite;
    private inspection inspect;
    private Skip skip;
    GameObject textwr;
    private float f = 0.02f; //write delay, aka textspeed
    public int txtWriterNr = 1;
    private bool eventWait = false; // only true in the case of a sound/event to prevent normal read chapter from working in that case 
    private bool eventCall = false; //turns true when an eventDisplay call is ready and turns false again after the eventDisplay was executed.
    private bool eventCalled = true; //alternates with eventCall. Only 1 of both can be true at all times.

    private void Awake()
    {
        titlewrite = GameObject.Find("Title").GetComponent<TitleWrite>();
        inspect = GameObject.Find("InspectionFactory").GetComponent<inspection>();
        skip = GameObject.Find("Skip").GetComponent<Skip>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        textwriter = new GameObject("textwriter"); //textwriter

        textwr = Instantiate(textwriter); //instance of textwriter
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite>(); //add functionality to textwriter instance
    }
	
	void Update () {

        if (textwr == null) {
            textwr = GameObject.Find("textwriter(Inst)" + txtWriterNr);
        }

        // Only attempt writing at all if controller hasn't disabled it
        if (controller.enableWrite == true && controller.gameMode == 0)
        {
            //Part of Controller start
            if (Input.GetKeyDown("space") && controller.getRunDisplay() == 0 && novel.getCurrentLine() == -1)
            {
                Debug.Log("Ch0 on");
                controller.startCh0();
            }
            // DisplayCh1 can be called multiple times parallely without... && controller.getRunDisplay() == 0 
            else if ((Input.GetKeyDown("space") || (skip.autoOn == true && skip.skipOn == false) || (skip.skipOn == true && skip.autoOn == false))
                 && novel.getCurrentLine() >= 7)
            {
                Debug.Log("Ch1 on");
                controller.startCh1();
            }
            //Part of Controller end

            //Auto-call
            if (skip.skipOn == false && skip.autoOn == true && textwr.GetComponent<TextWrite>().run == false)
        {
                Debug.Log("case 1");
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptAuto();

                //change color for thought-text
                if (novel.getCurrentLine() == 9 || novel.getCurrentLine() == 12 || novel.getCurrentLine() == 14 ||
                    novel.getCurrentLine() == 24 || novel.getCurrentLine() == 29 || novel.getCurrentLine() > 35 && novel.getCurrentLine() < 45)
                {
                    Debug.Log("colorchange in " + novel.getCurrentLine());
                    GameObject.Find("Textbox").GetComponent<Text>().color = new Color(0f, 0.8f, 0.8f);
                }
                else
                {
                    GameObject.Find("Textbox").GetComponent<Text>().color = new Color(1f, 1f, 1f);
                }
            }
        //Skip-call only if skippin isn't currently running for the 2nd time
            else if (skip.skipOn == true && skip.autoOn == false && (textwr.GetComponent<TextWrite>().run == false || textwr.GetComponent<TextWrite>().skippin == false))
        {
                Debug.Log("case 2");
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
                txtWriterNr += 1;
                textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptSkip();

                //change color for thought-text
                if (novel.getCurrentLine() == 9 || novel.getCurrentLine() == 12 || novel.getCurrentLine() == 14 ||
                    novel.getCurrentLine() == 24 || novel.getCurrentLine() == 29 || novel.getCurrentLine() > 35 && novel.getCurrentLine() < 45)
                {
                    Debug.Log("colorchange in " + novel.getCurrentLine());
                    GameObject.Find("Textbox").GetComponent<Text>().color = new Color(0f, 0.8f, 0.8f);
                }
                else
                {
                    GameObject.Find("Textbox").GetComponent<Text>().color = new Color(1f, 1f, 1f);
                }
            }
            //Normal Read-Chapter-call
            else if (Input.GetKeyDown("space") && skip.skipOn == skip.autoOn && eventWait == false)
        {
                //checks if eventlines n-1 are reached.
                if(eventCalled == true)
                {
                    switch (novel.getCurrentLine())
                    {
                        case 19:
                        case 21:
                        case 22:
                        case 29:
                            eventCall = true;
                            eventCalled = false;
                            break;
                    }
                } else {
                    eventCall = false;
                        }

                //prevents reading if eventline is reached and plays event instead.
                if(eventCall == true)
                {
                //displays cutscene
                switch (novel.getCurrentLine())
                {
                    case 21:
                        StartCoroutine(displayEvent(0));
                        break;
                    case 19:
                        StartCoroutine(displayEvent(1));
                        break;
                    case 22:
                        StartCoroutine(displayEvent(2));
                        break;
                        case 29:
                        StartCoroutine(displayEvent(3));
                        break;
                }
                    eventCall = false;
                } else //otherwise reads normally if no event is currently ongoing
                {
                    //writes the text
                    Debug.Log("case 3: Normal Read");
                    GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

                    Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                    GameObject textwr = Instantiate(textwriter);
                    txtWriterNr += 1;
                    textwr.name = "textwriter(Inst)" + txtWriterNr;
                    textwr.AddComponent<TextWrite>();
                    textwr.GetComponent<TextWrite>().setF(f);
                    textwr.GetComponent<TextWrite>().attemptWriting();

                    //change namebox & chars
                    switch (novel.getCurrentLine())
                    {
                        case 33: case 35:
                            GameObject.Find("T8").GetComponent<Text>().text = "???";
                            controller.charDisplay(2);
                            GameObject.Find("Char2").GetComponent<CanvasRenderer>().SetAlpha(0.4f);
                            GameObject.Find("Char1").GetComponent<Image>().sprite = spritecontainer.loadAvatar(21);
                            break;
                        case 34:
                        case 36:
                            GameObject.Find("Char2").GetComponent<CanvasRenderer>().SetAlpha(1f);
                            GameObject.Find("Char1").GetComponent<CanvasRenderer>().SetAlpha(0.4f);
                            GameObject.Find("T8").GetComponent<Text>().text = "Sabrina";
                            break;
                        case 37:
                            controller.charDisplay(1);
                            GameObject.Find("BlackFog2").GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
                            break;
                        case 38:
                            controller.charDisplay(1);
                            GameObject.Find("BlackFog2").GetComponent<RectTransform>().localPosition = new Vector3(1000f, 0f, 0f);
                            break;
                    }

                    //change color for thought-text
                    if (novel.getCurrentLine() == 9 || novel.getCurrentLine() == 12 || novel.getCurrentLine() == 14 ||
                        novel.getCurrentLine() == 24 || novel.getCurrentLine() == 29 || novel.getCurrentLine() > 35 && novel.getCurrentLine() < 45)
                    {
                        Debug.Log("colorchange in " + novel.getCurrentLine());
                        GameObject.Find("Textbox").GetComponent<Text>().color = new Color(0f, 0.8f, 0.8f);
                    }
                    else
                    {
                        GameObject.Find("Textbox").GetComponent<Text>().color = new Color(1f, 1f, 1f);
                    }

                    eventCalled = true; //reset checking for eventDisplay
                }
        }

        }
        // Enable writing for inspection text
        else if (controller.enableWrite == false && controller.gameMode == 0 && GameObject.Find("iO(Inst)1") != null)
        {
            //Textwrite
            if (Input.GetKeyDown("space") && inspect.inspectionType == 0)
            {
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                controller.gameMode = 1;
                GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0f);
                controller.charDisplay(3);
                GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
            }
            // Item Found
            else if (Input.GetKeyDown("space") && inspect.inspectionType == 1)
            {
                controller.gameMode = 1;
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0f);
                controller.charDisplay(3);

                GameObject.Find("ItemObtained").GetComponent<RectTransform>().localPosition = new Vector2(0f, 19f);
                GameObject.Find("YouFound").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
                StartCoroutine(itemObtainedAppear(inspect.itemId));

                inspect.changeListener(inspect.lastClicked);

            }
            // Coins Found
            else if (Input.GetKeyDown("space") && inspect.inspectionType == 2)
            {
                controller.gameMode = 1;
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0f);
                controller.charDisplay(3);

                GameObject.Find("CoinsObtained").GetComponent<RectTransform>().localPosition = new Vector2(200f, 150f);
                StartCoroutine(coinObtainedAppear(inspect.getCoinAmount()));

                inspect.changeListener(inspect.lastClicked);
            }
            // Decision Time
            else if (Input.GetKeyDown("space") && inspect.inspectionType == 3)
            {
                controller.gameMode = 1;
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("UI_Panel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NameBox").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("T8").GetComponent<CanvasRenderer>().SetAlpha(0f);
                controller.charDisplay(3);


                GameObject.Find("2Decision").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
                StartCoroutine(decisionAppear());
            }

        }
    }

    //separate call of NormalRead outside of Update
    public void attemptNormalRead()
    {
        //writes the text
        Debug.Log("case 3: Normal Read");
        GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

        Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
        GameObject textwr = Instantiate(textwriter);
        txtWriterNr += 1;
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite>();
        textwr.GetComponent<TextWrite>().setF(f);
        textwr.GetComponent<TextWrite>().attemptWriting();

        //change namebox & chars
        switch (novel.getCurrentLine())
        {
            case 33:
            case 35:
                GameObject.Find("NameBox").GetComponent<Text>().text = "???";
                controller.charDisplay(2);
                GameObject.Find("Char1").GetComponent<Image>().sprite = spritecontainer.loadAvatar(1);
                break;
        }

        //change color for thought-text
        if (novel.getCurrentLine() == 9 || novel.getCurrentLine() == 12 || novel.getCurrentLine() == 14 ||
            novel.getCurrentLine() == 24 || novel.getCurrentLine() == 29 || novel.getCurrentLine() > 35 && novel.getCurrentLine() < 45)
        {
            Debug.Log("colorchange in " + novel.getCurrentLine());
            GameObject.Find("Textbox").GetComponent<Text>().color = new Color(0f, 0.8f, 0.8f);
        }
        else
        {
            GameObject.Find("Textbox").GetComponent<Text>().color = new Color(1f, 1f, 1f);
        }

        eventCalled = true; //reset checking for eventDisplay
    }

    // Displays different events depending on switch case including play sound, display title, pauses etc.
    IEnumerator displayEvent(int eventId)
    {
        eventWait = true;
        switch (eventId)
        {
            case 0:
                //...30 minutes later...
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                controller.charDisplay(3);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("BlackFog").GetComponent<CanvasRenderer>().SetAlpha(0.8f);
                GameObject.Find("BlackFog").GetComponent<Transform>().localPosition = new Vector3(0f,0f,0f);
                titlewrite.displayTitle(4, 0); //fade in title: 30 minutes later
                GameObject.Find("SFX3").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2f);
                titlewrite.hideTitle(); //fade out title
                GameObject.Find("SFX3").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2f);
                GameObject.Find("BlackFog").GetComponent<Transform>().localPosition = new Vector3(1000f, 0f, 0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(1f);
                controller.charDisplay(1);
                break;
            case 1:
                // Door Pound before 30 minutes later
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("SFX3").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(1f);
                break;
            case 2:
                // ...2 hours later...
                controller.charDisplay(3);
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("BlackFog").GetComponent<CanvasRenderer>().SetAlpha(0.8f);
                GameObject.Find("BlackFog").GetComponent<Transform>().localPosition = new Vector3(0f, 0f, 0f);
                titlewrite.displayTitle(5, 0); //fade in title: 2 hours later
                yield return new WaitForSeconds(2f);
                titlewrite.hideTitle(); //fade out title
                yield return new WaitForSeconds(2f);
                GameObject.Find("BlackFog").GetComponent<Transform>().localPosition = new Vector3(1000f, 0f, 0f);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(1f);
                controller.charDisplay(1);
                break;
            case 3:
                controller.charDisplay(3);
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0f);
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
                GameObject.Find("SFX4").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2.1f);
                controller.charDisplay(1);
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(1f);
                break;
        }
        eventWait = false;
    }

    //external call of play sound
    public void playSFX()
    {
        StartCoroutine(playSound());
    }

    //Plays sound during text
    IEnumerator playSound()
    {
            eventWait = true;
            GameObject.Find("SFX5").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.5f);
            eventWait = false;
    }

    IEnumerator decisionAppear()
    {
        //Decision window appear
        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("2Decision").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("2Decision").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Pick1").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Pick1").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("Pick2").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("Pick2").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("2DecisionTextPanel").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("2DecisionTextPanel").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("choice1").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("choice1").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("choice2").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("choice2").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("2DecisionText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("2DecisionText").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
        }

        //Choose decision based on id
        switch (inspect.getDecision())
        {
            case 1: //weapon-pick decision
                GameObject.Find("2DecisionText").GetComponent<Text>().text = "Pick up the Colt .357 Revolver?";
                GameObject.Find("choice1").GetComponent<Text>().text = "Let's take it.";
                GameObject.Find("choice2").GetComponent<Text>().text = "Leave it there.";
                GameObject.Find("Pick1").GetComponent<Button>().onClick.AddListener(() => {
                    // Change listener
                    inspect.itemFound3 = 1;
                    inspect.changeListener(inspect.lastClicked);

                    //Decision window disappear
                    GameObject.Find("2Decision").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("Pick1").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("Pick2").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("2DecisionTextPanel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("choice1").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("choice2").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("2DecisionText").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("2Decision").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

                    GameObject.Find("ItemObtained").GetComponent<RectTransform>().localPosition = new Vector2(0f, 19f);
                    GameObject.Find("YouFound").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
                    StartCoroutine(itemObtainedAppear(inspect.itemId));
                });
                GameObject.Find("Pick2").GetComponent<Button>().onClick.AddListener(() => {
                    inspect.itemFound3 = 0;

                    //Decision window disappear
                    GameObject.Find("2Decision").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("Pick1").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("Pick2").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("2DecisionTextPanel").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("choice1").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("choice2").GetComponent<CanvasRenderer>().SetAlpha(0f);
                    GameObject.Find("2DecisionText").GetComponent<CanvasRenderer>().SetAlpha(0f);

                    GameObject.Find("2Decision").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

                    GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
                });
                break;
        }

    }

        IEnumerator coinObtainedAppear(int coinAmount)
    {

        GameObject.Find("CoinNr").GetComponent<Text>().text = coinAmount.ToString();

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("CoinsObtained").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinsObtained").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("CoinsFound").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinsFound").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("CoinNr").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinNr").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(1f);

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("CoinsObtained").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinsObtained").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
            GameObject.Find("CoinsFound").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinsFound").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
            GameObject.Find("CoinNr").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("CoinNr").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        GameObject.Find("CoinsObtained").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

        GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
    }

    IEnumerator itemObtainedAppear(int itemID)
    {

        //Change Item image & text before displaying
        GameObject.Find("FoundItem").GetComponent<Image>().sprite = items.getItemSprite(itemID);
        GameObject.Find("YouFoundText").GetComponent<Text>().text = "You found " + items.getItemName(itemID);

        //Display elements in the following order
        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("YouFound").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("YouFound").GetComponent<CanvasRenderer>().GetAlpha() + 0.04f);
            GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().GetAlpha() + 0.2f);
            yield return new WaitForSeconds(0.08f);
        }

        for (int k = 0; k < 5; k++)
        {
            GameObject.Find("YouFoundText").GetComponent<CanvasRenderer>().SetAlpha(1f);
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(2f);

        for (int k = 0; k < 5; k++)
        {
        GameObject.Find("YouFound").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("YouFound").GetComponent<CanvasRenderer>().GetAlpha() - 0.04f);
        GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("YouFoundText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("YouFoundText").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        yield return new WaitForSeconds(0.08f);
        }

        GameObject.Find("ItemObtained").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);
        GameObject.Find("YouFound").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

        GameObject.Find("InspectionElements").GetComponent<RectTransform>().localPosition = new Vector2(0f, 0f);
    }

    public void createTextWriterInst()
    {
        if (GameObject.Find("textwriter(Inst)" + txtWriterNr) != null)
        {
            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
        }
        GameObject textwr = Instantiate(textwriter);
        txtWriterNr += 1;
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite>();
        textwr.GetComponent<TextWrite>().setF(f);
    }

    public float getF()
    {
        return f;
    }

    public void setF(float fl)
    {
        f = fl;
        GameObject.Find("textwriter(Inst)" + txtWriterNr).GetComponent<TextWrite>().setF(fl);
    }

}

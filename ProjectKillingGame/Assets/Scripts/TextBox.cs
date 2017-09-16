using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public Novel novel;
    public Items items;
    private GameObject textwriter;
    private Controller controller;
    private inspection inspect;
    private Skip skip;
    GameObject textwr;
    private float f = 0.02f; //write delay, aka textspeed
    public int txtWriterNr = 1;
    private bool eventWait = false; // only true in the case of a sound/event to prevent normal read chapter from working in that case 

    private void Awake()
    {
        inspect = GameObject.Find("InspectionFactory").GetComponent<inspection>();
        skip = GameObject.Find("Skip").GetComponent<Skip>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        textwriter = new GameObject("textwriter"); //textwriter

        textwr = Instantiate(textwriter); //instance of textwriter
        textwr.name = "textwriter(Inst)" + txtWriterNr;
        textwr.AddComponent<TextWrite>(); //add functionality to textwriter instance
    }
	
	void Update () {
        //Line of every event/sound, eventWait is set to true 
        //TODO: fix
        if (novel.getCurrentLine() == 19 || novel.getCurrentLine() == 20) 
        {
            eventWait = true;
        }

        if (textwr == null) {
            textwr = GameObject.Find("textwriter(Inst)" + txtWriterNr);
        }

        // Only attempt writing at all if controller hasn't disabled it
        if (controller.enableWrite == true && controller.gameMode == 0)
        {
        //Auto-call
        if (skip.skipOn == false && skip.autoOn == true && textwr.GetComponent<TextWrite>().run == false)
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
            txtWriterNr += 1;
            textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptAuto();
        }
        //Skip-call only if skippin isn't currently running for the 2nd time
            else if (skip.skipOn == true && skip.autoOn == false && (textwr.GetComponent<TextWrite>().run == false || textwr.GetComponent<TextWrite>().skippin == false))
        {
            GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

            Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
            GameObject textwr = Instantiate(textwriter);
                txtWriterNr += 1;
                textwr.name = "textwriter(Inst)" + txtWriterNr;
            textwr.AddComponent<TextWrite>();
            textwr.GetComponent<TextWrite>().setF(f);
            textwr.GetComponent<TextWrite>().attemptSkip();
        }
            //Normal Read-Chapter-call
            //TODO: fix
            else if (Input.GetKeyDown("space") && skip.skipOn == skip.autoOn && controller.getRunDisplay() == 0 && controller.eventWait == false && eventWait == false)
        {
                Debug.Log("case 3");
                    GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

                    Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                    GameObject textwr = Instantiate(textwriter);
                    txtWriterNr += 1;
                    textwr.name = "textwriter(Inst)" + txtWriterNr;
                    textwr.AddComponent<TextWrite>();
                    textwr.GetComponent<TextWrite>().setF(f);
                    textwr.GetComponent<TextWrite>().attemptWriting();
        }
            //Read-Chapter normally only AFTER Sound/Event is off
            //TODO: fix
            else if (skip.skipOn == skip.autoOn && controller.getRunDisplay() == 0 && controller.eventWait == true)
            {
                Debug.Log("case 4");
                controller.eventWait = false;
                eventWait = false;
                GameObject.Find("NextPage").GetComponent<CanvasRenderer>().SetAlpha(0.00f);

                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject textwr = Instantiate(textwriter);
                txtWriterNr += 1;
                textwr.name = "textwriter(Inst)" + txtWriterNr;
                textwr.AddComponent<TextWrite>();
                textwr.GetComponent<TextWrite>().setF(f);
                textwr.GetComponent<TextWrite>().attemptWriting();
            }
        }
        // Enable writing for inspection text
        else if (controller.enableWrite == false && controller.gameMode == 0 && GameObject.Find("iO(Inst)1") != null)
        {
            //Textwrite
            if (Input.GetKeyDown("space") && inspect.inspectionType == 0)
            {
                controller.gameMode = 1;
                Destroy(GameObject.Find("textwriter(Inst)" + txtWriterNr));
                GameObject.Find("Textbox").GetComponent<Text>().text = "";
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
        GameObject.Find("textwriter(Inst)").GetComponent<TextWrite>().setF(fl);
    }

}

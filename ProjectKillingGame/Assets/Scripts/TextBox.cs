using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public Items items;
    private GameObject textwriter;
    private Controller controller;
    private inspection inspect;
    private Skip skip;
    GameObject textwr;
    private float f = 0.02f; //write delay, aka textspeed
    public int txtWriterNr = 1;

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
            //Normal ReadChapter-call
        } else if (Input.GetKeyDown("space") && skip.skipOn == skip.autoOn)
        {
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

                for (int i = 1; i < 9; i++)
                {
                    GameObject.Find("iO(Inst)" + i).GetComponent<Button>().enabled = true;
                }
            }

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

        for (int i = 1; i < 9; i++)
        {
            GameObject.Find("iO(Inst)" + i).GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator itemObtainedAppear(int itemID)
    {
        //Change Item image & text before displaying
        GameObject.Find("FoundItem").GetComponent<Image>().sprite = items.getItemSprite(itemID);
        GameObject.Find("YouFoundText").GetComponent<Text>().text = GameObject.Find("YouFoundText").GetComponent<Text>().text + items.getItemName(itemID);

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

        yield return new WaitForSeconds(1f);

        for (int k = 0; k < 5; k++)
        {
        GameObject.Find("YouFound").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("YouFound").GetComponent<CanvasRenderer>().GetAlpha() - 0.04f);
        GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemObtained").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("YouFoundText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("ItemBG").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        GameObject.Find("ObtainedText").GetComponent<CanvasRenderer>().SetAlpha(GameObject.Find("FoundItem").GetComponent<CanvasRenderer>().GetAlpha() - 0.2f);
        yield return new WaitForSeconds(0.08f);
        }

        GameObject.Find("ItemObtained").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);
        GameObject.Find("YouFound").GetComponent<RectTransform>().localPosition = new Vector2(1000f, 0f);

        for (int i = 1; i < 9; i++)
        {
            GameObject.Find("iO(Inst)" + i).GetComponent<Button>().enabled = true;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {

    public Load loadMenu;
    public SpriteCon spritecon;
    public Novel novel;
    public Controller control;
    public TextWrite textwr;

    public Sprite savefilesprite;
    private Vector2 vect = new Vector2(100f, 100f);
    public GameObject singlesave;
    public GameObject content;

    private int SFcount = 0; //count of savefiles
    private int spritenr; // id of savefile img
    private Time creationTime; //time savefile was created

    public bool firstbuttoncreated = false;

    public Button createButtonForSave(Sprite sprite, Vector2 size, GameObject canvas, int c)
    {
        GameObject go = new GameObject("Savefile");

        Image image = go.AddComponent<Image>();
        image.sprite = sprite;
        image.rectTransform.sizeDelta = size;

        Button button = go.AddComponent<Button>();
        go.transform.SetParent(canvas.transform, false);

        image.rectTransform.position = image.rectTransform.localPosition + new Vector3(0f, 100f*c, 0f);
        GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta = GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta + new Vector2(0f, 100f);
        firstbuttoncreated = true;

        return button;
    }

    public void saveData()
    {
        if (GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().GetAlpha() == 1f)
        {
            GameObject.Find("LoadMenu").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("LoadMenu").GetComponent<RectTransform>().Translate(new Vector2(0f, -450f));
            GameObject.Find("CloseLoadMenu").GetComponent<Button>().interactable = false;
            GameObject.Find("ScrollLoadedData").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("T9").GetComponent<CanvasRenderer>().SetAlpha(0f);
            GameObject.Find("Scrollbar").GetComponent<Scrollbar>().interactable = false;
            GameObject.Find("Scrollbar").GetComponent<CanvasRenderer>().SetAlpha(0f);
        }

        int loopcount = 1;
        for (int i = 0;i<loopcount; i++)
        {
            if (PlayerPrefs.HasKey("textspeed" + 1*loopcount))
            {
                loopcount += 1;
            } else {
                PlayerPrefs.SetFloat("textspeed" + 1*loopcount, textwr.getF());
                PlayerPrefs.SetInt("currentBG" + 1 * loopcount, control.currentBG);
                PlayerPrefs.SetInt("Char1" + 1 * loopcount, control.getChar1());
                PlayerPrefs.SetInt("Char2" + 1 * loopcount, control.getChar2());
                PlayerPrefs.SetInt("currentIndex" + 1 * loopcount, novel.savedIndex);
                PlayerPrefs.SetInt("currentLine" + 1 * loopcount, novel.getCurrentLine());
                PlayerPrefs.Save();
                singlesave.GetComponent<SaveFile>().setAll(loopcount);
                loopcount = 1;
            }
        }

        loadMenu.getSaveFiles().Add(singlesave); //Add savefile to list of savefiles

        int count = loadMenu.getCount();
        createButtonForSave(savefilesprite, vect, content, count);
    }
}

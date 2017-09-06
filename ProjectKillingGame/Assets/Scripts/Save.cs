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
    private GameObject singlesave;
    public GameObject content;

    public static Button createButtonForSave(Sprite sprite, Vector2 size, GameObject canvas)
    {
        GameObject go = new GameObject("Savefile");

        Image image = go.AddComponent<Image>();
        image.sprite = sprite;

        Button button = go.AddComponent<Button>();
        go.transform.SetParent(canvas.transform, false);

        image.rectTransform.sizeDelta = size;
        image.rectTransform.position = image.rectTransform.localPosition + new Vector3(0f, 0f, 0f);

        return button;
    }

    public void saveData()
    {
        PlayerPrefs.SetFloat("textspeed", textwr.getF());
        PlayerPrefs.SetInt("currentBG", control.currentBG);
        PlayerPrefs.SetInt("Char1", control.getChar1());
        PlayerPrefs.SetInt("Char2", control.getChar2());
        PlayerPrefs.SetInt("currentIndex", novel.savedIndex);
        PlayerPrefs.SetInt("currentLine", novel.getCurrentLine());
        PlayerPrefs.Save();

        int count = loadMenu.getCount();
        createButtonForSave(savefilesprite, vect, content);
    }
}

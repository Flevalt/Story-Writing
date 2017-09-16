using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClicks : MonoBehaviour {

    private bool compendiumOpen = false;
    private bool statusOpen = false;
    private bool mapOpen = false;
    private bool settingsOpen = false;

    public void showCompendium()
    {
            GameObject.Find("Compendium").GetComponentInChildren<RectTransform>().position = new Vector2(340f, 250f);
            compendiumOpen = true;
    }

    public void showStatus()
    {

            GameObject.Find("StatusOverview").GetComponentInChildren<RectTransform>().position = new Vector2(340f, 250f);
            statusOpen = true;
    }

    public void showMap()
    {

            GameObject.Find("Map").GetComponentInChildren<RectTransform>().position = new Vector2(340f, 250f);
            mapOpen = true;
    }

    public void showSettings()
    {
        GameObject.Find("Settings").GetComponentInChildren<RectTransform>().position = new Vector2(340f, 250f);
        settingsOpen = true;
    }

    public bool getCompOpen()
    {
        return compendiumOpen;
    }

    public bool getStatOpen()
    {
        return statusOpen;
    }

    public bool getMapOpen()
    {
        return mapOpen;
    }

    public bool getSettingsOpen()
    {
        return settingsOpen;
    }

    public void setSettingsOpen(bool i)
    {
        settingsOpen = i;
    }

    public void setCompOpen(bool i)
    {
        compendiumOpen = i;
    }

    public void setStatOpen(bool i)
    {
        statusOpen = i;
    }

    public void setMapOpen(bool i)
    {
        mapOpen = (i);
    }
}

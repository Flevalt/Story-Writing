using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectResolution : MonoBehaviour
{
    Dropdown drop;
    Resolution[] resolutions = Screen.resolutions;

    void Start()
    {
        List<string> list = new List<string>();
        var dropdown = GetComponent<Dropdown>();
        dropdown.options.Clear();

        //Fill Resolutionlist with all available resolutions.
        foreach (Resolution res in resolutions)
        {
            list.Add(res.width.ToString() + " x " + res.height.ToString());
        }

        //Fill Dropdown menu with resolution options from list.
        foreach (string option in list)
        {
            dropdown.options.Add(new Dropdown.OptionData(option));
        }
    }

    void ChangeResolution()
    {
        Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
    }
}

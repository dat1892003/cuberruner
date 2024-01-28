using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scText;
    
    public GameObject overPanel;

    public GameObject stPanel;

    public void setsc(string txt)
    {
        if (scText)
            scText.text  = txt;
    }
    public void showgameover(bool show)
    {
        if (overPanel)
            overPanel.SetActive(show);
    }
    public void showGamestart(bool show)
    {
        if (stPanel)
            stPanel.SetActive(show);
    }
}

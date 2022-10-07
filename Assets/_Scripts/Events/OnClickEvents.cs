using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI muteText;  
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.MuteGame)
        {
            muteText.SetText("/");
        }
        else
            muteText.SetText(" "); 
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void ToggleSound()
    {
        if (!GameManager.instance.MuteGame)
        {
            GameManager.instance.MuteGame = true; 
            muteText.SetText("/");
        }
        else
        {
            GameManager.instance.MuteGame = false; 
            muteText.SetText(" ");
        }
    }
}

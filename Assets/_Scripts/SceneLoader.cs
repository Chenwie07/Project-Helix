using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ShowLeaderboard()
    {
        if (!GameManager.instance.connectedToGooglePlay)
        {
            // call the login method 
            return; 
        }
        Social.ShowLeaderboardUI(); 
    }
}

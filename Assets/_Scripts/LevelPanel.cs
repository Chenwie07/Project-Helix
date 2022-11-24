using System;
using UnityEngine;
using UnityEngine.UI;


public class LevelPanel : MonoBehaviour
{
    public GameObject[] levelMarkers;
    public Button[] levelsBlocker;
    private int leaderboardScore;

    // there must exist a more optimized way to achieve this. 
    private void Start()
    {
        // Don't unlock other levels if you haven't cmpleted the previous one. 
        UnlockLevel();
        leaderboardScore = PlaceMarkers() * 1000; 
        PlayUtilityManager.instance.PostScoreOnLeaderBoard(leaderboardScore);
    }

    private int PlaceMarkers()
    {
        int totalMarkers = 0; 
        for (int i = 0; i < levelMarkers.Length; i++)
        {
            if (PlayerPrefs.GetString("Level " + (i + 1) + " Completed") == "YES")
            {
                levelMarkers[i].SetActive(true);
                totalMarkers += 1 ; // we will display this score on the leaderboard on play. 
            }
        }
        return totalMarkers; 
    }
    private void UnlockLevel()
    {
        // 0 is level 2. 
        for (int i = 0; i < levelsBlocker.Length; i++)
        {
            if (PlayerPrefs.GetString("Level " + (i+1) + " Completed") == "YES" && levelsBlocker[i].interactable != true)
            {
                // when you complete a level, unlock the next one. 
                levelsBlocker[i].interactable = true; 
                //Debug.Log("Next level Unlocked, play sound or animation effect to spice it up"); 

                //Depending on which level is being unlocked, the player must have completed a level to give a reward
                if (i == 3)
                {
                    PlayUtilityManager.instance.UnlockAchievement(ProjectHelixGPGSIds.achievement_complete_first_live_tower); 
                }
                if (i == 5)
                {
                    PlayUtilityManager.instance.UnlockAchievement(ProjectHelixGPGSIds.achievement_complete_first_double_trouble); 
                }
                if (i == 8)
                {
                    PlayUtilityManager.instance.UnlockAchievement(ProjectHelixGPGSIds.achievement_complete_first_night_tower); 
                }
            }
        }
    }
}

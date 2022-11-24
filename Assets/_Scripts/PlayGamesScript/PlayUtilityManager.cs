using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlayUtilityManager : MonoBehaviour
{
    public static PlayUtilityManager instance;
    public GameObject[] GPlayPanels;
    public bool ConnectedToPlay { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayGamesPlatform.Activate();
        LogIntoPlay();
    }

    // this is a one line function. 
    internal void LogIntoPlay() => PlayGamesPlatform.Instance.
            Authenticate(ProcessAuthentication);
    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            //Debug.Log("Log in Successful");
            GPlayPanels[0].SetActive(false);
            GPlayPanels[1].SetActive(true);
            GPlayPanels[2].SetActive(true);
            ConnectedToPlay = true;

            UnlockAchievement(ProjectHelixGPGSIds.achievement_log_into_project_helix); 
        }
        else
        {
            //Debug.Log("Log in Unsuccessful");
            GPlayPanels[0].SetActive(true);
            GPlayPanels[1].SetActive(false);
            GPlayPanels[2].SetActive(false);
            ConnectedToPlay = false;
        }
    }
    public void PostScoreOnLeaderBoard(int score)
    {
        Social.ReportScore(score, ProjectHelixGPGSIds.leaderboard_projecthelixleaderboard, (bool success) =>
        {
            //Debug.Log("Leaderboard successfully updated"); 
        });
    }

    public void ShowLeaderboard()
    {
        if (ConnectedToPlay)
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ProjectHelixGPGSIds.leaderboard_projecthelixleaderboard);
        else
            LogIntoPlay();
    }

    public void ShowAchievements()
    {
        if (ConnectedToPlay)
        {
            // call Achievement to show
            PlayGamesPlatform.Instance.ShowAchievementsUI(); 
        }
        else
        {
            LogIntoPlay();
        }
    }
    public void UnlockAchievement(string AchievementString)
    {
        if (ConnectedToPlay)
        {
            PlayGamesPlatform.Instance.UnlockAchievement(AchievementString); 
        }
    }
}

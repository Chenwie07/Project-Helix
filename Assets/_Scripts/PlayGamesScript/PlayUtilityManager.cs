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
    public Text _signInStatus;
    public Text _scoreUpdateStatus;
    public bool ConnectedToPlay { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.Activate();
        instance = this;
        LogIntoPlay(); 
    }

    // this is a one line function. 
    internal void LogIntoPlay() => PlayGamesPlatform.Instance.
            Authenticate(ProcessAuthentication);
    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            _signInStatus.text = "Success";
            ConnectedToPlay = true;
        }
        else
        {
            ConnectedToPlay = false;
            _signInStatus.text = "Failure";
        }
    }

    public void PostScoreOnLeaderBoard(int score)
    {
        Social.ReportScore(score, ProjectHelixGPGSIds.leaderboard_projecthelixleaderboard, (bool success) =>
        {
            if (success)
                _scoreUpdateStatus.text = "Success updating Score";
            else
                _scoreUpdateStatus.text = "Failure to Update score";
        });
    }

    public void ShowLeaderboard()
    {
        if (ConnectedToPlay)
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ProjectHelixGPGSIds.leaderboard_projecthelixleaderboard);
        else
            LogIntoPlay(); 
    }
}
